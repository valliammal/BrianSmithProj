using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


public partial class SQL_UpdateTable : System.Web.UI.Page
{

    DataConnectivity dc = new DataConnectivity();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnFire_Click(object sender, EventArgs e)
    {
        try
        {
            string drop1 = "drop table Language";
            string drop2 = "drop table Country";
            string TLanguage = "create table Language(Lang_ID int primary key identity(1,1),Lang_Name nvarchar(max) not null)";
            string TCountry = "create table Country(C_ID int identity primary key,CountryName nvarchar(max) not null,CountryCode nvarchar(max) not null)";
            string CountryData = "insert into Country(CountryName,CountryCode) values ('----SELECT COUNTRY----',''),('AFGHANISTAN','+93'),('ALBANIA','+355'),('ALGERIA','+213'),('AMERICAN SAMOA','+1684'),('ANDORRA','+376'),('ANGUILLA','+1264'),('ANTARCTICA','+0'),('ANTIGUA AND BARBUDA','+1268'),('ALGERIA','+213'),('ARGENTINA','+54'),('ARMENIA','+374'),('ARUBA','+297'),('AUSTRALIA','+61'),('AUSTRIA','+43'),('AZERBAIJAN','+994'),('BAHAMAS','+1242'),('BAHRAIN','+1242'),('BANGLADESH','+880'),('BARBADOS','+1246'),('BELARUS','+375'),('BELGIUM','+32'),('BELIZE','+501'),('BENIN','+229'),('BERMUDA','+1441'),('BHUTAN','+975'),('BOLIVIA','+591'),('BOSNIA AND HERZEGOVINA','+387'),('BOTSWANA','+267'),('BRAZIL', '+55'),('BRUNEI DARUSSALAM','+ 673'),('BULGARIA', '+359'),('BURKINA FASO', '+226'),('BURUNDI', '+257'),('CAMBODIA','+855'),('CAMEROON',  '+237'),('CANADA', '+1'),('CAPE VERDE', '+238'),('CAYMAN ISLANDS', '+1345'),('CHAD',   '+235'),('CHILE',  '+56'),('CHINA',  '+86'),('CHRISTMAS ISLAND',  '+61'),('COLOMBIA',  '+57'),('COMOROS',  '+269'),('CONGO',  '+242'),('COOK ISLANDS',  '+682'),('COSTA RICA', '+506'),('COTE D IVOIRE', '+225'),('CROATIA',  '+385'),('CUBA',  '+53'),('CYPRUS','+357'),('CZECH REPUBLIC', '+420'),('DENMARK', '+45'),('DJIBOUTI', '+253'),('DOMINICA',  '+1767'),('DOMINICAN REPUBLIC',  '+1809'),('ECUADOR', '+593'),('EGYPT', '+20'),( 'EL SALVADOR', '+503'),('EQUATORIAL GUINEA', '+240'),( 'ERITREA', '+291'),( 'ESTONIA', '+372'),('ETHIOPIA', '+251'),('FAROE ISLANDS', '+298'),('FIJI','+679'),('FINLAND', '+358'),('FRANCE', '+33'),( 'FRENCH GUIANA','+594'),('FRENCH POLYNESIA', '+689'),( 'GABON', '+241'),('GAMBIA', '+220'),( 'GEORGIA', '+995'),( 'GERMANY', '+49'),( 'GHANA', '+233'),( 'GIBRALTAR',  '+350'),( 'GREECE', '+30'),( 'GREENLAND',  '+299'),( 'GRENADA',  '+1473'),( 'GUADELOUPE',  '+590'),( 'GUAM','+1671'),('GUATEMALA',  '+502'),('GUINEA',  '+224'),('GUINEA-BISSAU', '+245'),('GUYANA', '+6592'),('HAITI', '+509'),('HONDURAS',  '+504'),('HONG KONG',  '+852'),( 'HUNGARY', '+36'),('ICELAND', '+354'),('INDIA',  '+91'),('INDONESIA', '+62'),('IRAN', '+98'),('IRAQ', '+964'),('IRELAND', '+353'),('ISRAEL',  '+972'),('ITALY',  '+39'),('JAMAICA',  '+1876'),('JAPAN', '+81'),('JORDAN',  '+962'),('KAZAKHSTAN',  '+7'),('KENYA', '+254'),('KIRIBATI',  '+686'),('KOREA', '+850'),('KOREA','+82'),( 'KUWAIT',  '+965'),('KYRGYZSTAN',  '+996'),('LATVIA',  '+371'),('LEBANON', '+961'),('LESOTHO','+266'),('LIBERIA',  '+231'), ('LIBYAN ARAB JAMAHIRIYA',  '+218'),('LIECHTENSTEIN',  '+423'),('LITHUANIA', '+370'),('LUXEMBOURG', '+352'),('MACAO',  '+853'),('MACEDONIA', '+389'),('MADAGASCAR', '+261'),('MALAWI', '+265'),( 'MALAYSIA',  '+60'),('MALDIVES','+960'),( 'MALI',  '+223'),('MALTA', '+356'),('MARSHALL ISLANDS', '+692'),('MARTINIQUE', '+596'),( 'MAURITANIA',  '+222'),( 'MAURITIUS',  '+230'),('MAYOTTE',  '+269'),('MEXICO', '+52'),( 'MOLDOVA', '+373'),('MONACO',  '+377'),( 'MONGOLIA',  '+976'),( 'MONTSERRAT', '+1664'),( 'MOROCCO', '+212'),( 'MOZAMBIQUE', '+258'),( 'MYANMAR', '+95'),( 'NAMIBIA',  '+264'),( 'NAURU', '+674'),( 'NEPAL', '+977'),('NETHERLANDS', '+31'),('NETHERLANDS ANTILLES',  '+599'),('NEW CALEDONIA',  '+687'),( 'NEW ZEALAND',  '+64'),( 'NICARAGUA', '+505'),('NIGER',  '+227'),( 'NIGERIA', '+234'),( 'NIUE', '+683'),( 'NORFOLK ISLAND',  '+672'),( 'NORWAY', '+47'),( 'OMAN', '+968'),( 'PAKISTAN', '+92'),( 'PALAU',  '+680'),('PANAMA', '+507'),( 'PAPUA NEW GUINEA', '+675'),('PARAGUAY',  '+595'),( 'PERU',  '+51'),( 'PHILIPPINES',  '+63'),( 'POLAND',  '+48'),( 'PORTUGAL', '+351'),( 'PUERTO RICO', '+1787'),('QATAR', '+974'),( 'REUNION', '+262'),( 'ROMANIA',  '+40'),( 'RUSSIAN FEDERATION',  '+70'),( 'RWANDA',  '+250'),( 'SAINT HELENA', '+290'),( 'SAINT KITTS AND NEVIS', '+1869'),( 'SAINT LUCIA', '+1758'),( 'SAINT PIERRE AND MIQUELON','+508'),( 'SAMOA',  '+684'),( 'SAN MARINO',  '+378'),( 'SAO TOME AND PRINCIPE', '+239'),( 'SAUDI ARABIA', '+966'),( 'SENEGAL', '+221'),( 'SERBIA AND MONTENEGRO',  '+381'),('SEYCHELLES','+248'),( 'SIERRA LEONE', '+232'),( 'SINGAPORE',  '+65'),( 'SLOVAKIA', '+421'),('SLOVENIA', '+386'), ('SOLOMON ISLANDS',  '+677'),( 'SOMALIA',  '+252'),( 'SOUTH AFRICA',  '+27'),( 'SPAIN',  '+34'),('SRI LANKA',  '+94'),( 'SUDAN' , '+249'),( 'SURINAME', '+597'),('SWAZILAND', '+268'),( 'SWEDEN',  '+46'),( 'SWITZERLAND',  '+41'),( 'SYRIAN ARAB REPUBLIC', '+963'),('TAIWAN','+886'),('TAJIKISTAN',  '+992'),( 'TANZANIA ','+255'),( 'THAILAND',  '+66'),('TIMOR-LESTE', '+670'),( 'TOGO',  '+228'),( 'TOKELAU',  '+690'),( 'TONGA',  '+676'),( 'TUNISIA',  '+216'),( 'TURKEY', '+90'),( 'TURKMENISTAN', '+7370'),('TUVALU', '+688'),( 'UGANDA',  '+256'),( 'UKRAINE',  '+380'),( 'UNITED ARAB EMIRATES',  '+971'),( 'UNITED KINGDOM', '+44'),( 'UNITED STATES', '+1'),( 'URUGUAY', '+598'),( 'UZBEKISTAN',  '+998'),('VANUATU',  '+678'),( 'VENEZUELA', '+58'),( 'VIET NAM',  '+84'),('VIRGIN ISLANDS', '+1284'),('WALLIS AND FUTUNA', '+681'),( 'WESTERN SAHARA','+212'),( 'YEMEN',  '+967'),( 'ZAMBIA',  '+260'),( 'ZIMBABWE',  '+263')";
            int a = dc.ExecuteQuery(drop1);
            int b = dc.ExecuteQuery(drop2);
            int i = dc.ExecuteQuery(TLanguage);
            int j = dc.ExecuteQuery(TCountry);
            int k = dc.ExecuteQuery(CountryData);
            if (k > 0)
            {
                Response.Write("<script>alert('Tables are created.')</script>");
            }

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Error found: " + ex.Message.ToString() + ".')</script>");
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        string query = "select Lang_ID, Lang_Name from language";
        DataTable dt = dc.GetDataTable(query);
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

    }
    protected void btnShowC_Click(object sender, EventArgs e)
    {
        string query = "select C_ID,CountryName,CountryCode from Country";
        DataTable dt = dc.GetDataTable(query);
        if (dt.Rows.Count > 0)
        {
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }

    }
}