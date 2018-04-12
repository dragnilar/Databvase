# Databvase

<b>What is it?</b>

<u>Databvase</u> is a small, lightweight query tool, designed similarly to SQL Server Management Studio.  

It is a hobby project, so do not expect it to be anywhere as nearly as powerful as SSMS. 
Also expect it to have possible performance problems when compared to SSMS.

It primarily makes use of SMO and <a href="http://www.devexpress.com">DevExpress</a> to provide an experience that is close to SSMS in terms of basic functionality and
also providing some features that SSMS does not provide by default. 

Some of the features that it provides are:
<ul>
<li>The ability to customize the appearance of the application via DevExpress' skins, palletes and color switcher.</li>
<li>Data grid filtering, grouping and data exporting to various file types</li>
<li>Ability to run simultanious queries on multiple databases within one instance</li>
<li>The ability to run MOST queries (this needs more extensive testing).</li>
<li>Dockable windows and object explorer. </li>
</ul>

<b>NOTE:</b> Since this uses DevExpress, unfortunately, that means that if you wish to build from the source you will need to have 
DevExpress' libraries installed on your computer. This probably means you will need a license. 

This also uses icons from <a href="http://www.icons8.com">Icons8</a>.

Other dependencies:

<ul>
<li>Costura and Fody</li>
<li>Tyrrrz.Settings</li>
<li>Newtonsoft.Json</li>
<li>Micorsoft.SqlServer.Types</li>
<li>Microsoft.SqlServer.SqlManagementObjects</li>
</ul>

