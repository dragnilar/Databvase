# Databvase

<b>What is it?</b>

<u>Databvase</u> is a small, lightweight query tool, designed similarly to SQL Server Management Studio.  

This is a "fun" project, so do not expect this to have the same level of backing or development turn around as the likes of Microsoft or Jetbrains.

Also expect this to have possible performance problems when compared to SSMS (for now at least). If you find performance problems, please open an issue or comment on a pre-existing one in the issues section.

It primarily makes use of SMO and <a href="http://www.devexpress.com">DevExpress</a> to provide an experience that is close to SSMS in terms of basic functionality and
also providing some features that SSMS does not provide by default.

Some of the features that it provides are:
<ul>
<li>The ability to customize the appearance of the application via DevExpress' skins, palletes and color switcher.</li>
<li>Seperate but just as important, the ability to customize the colors of the text and backgrounds of the query editor to give yourself a more fine-tuned experience.</li>
<li>Data grid filtering, grouping and data exporting to various file types.</li>
<li>Flexible object explorer filtering.</li>
<li>Ability to right click and generate basic select *, select top * scripts .</li>
  <li>Ability to also script out alter and modify statements on views, stored procedures and functions.</li>
<li>Ability to run simultanious queries on multiple databases within one instance.</li>
<li>Like with SSMS, you can connect to multiple instances at once if need be to view multiple object explorer trees. </li>
<li>The ability to run MOST queries (we say most becuase this needs more extensive testing).</li>
<li>Dockable windows and object explorer. </li>
<li>Syntax highlighting for most keywords (such as SELECT, DROP, etc.), comments and strings.</li>
<li>Query builder tool that allows you to construct complex select/join statements via a visual aid </li>
<li>Backup wizard that lets you create database backups</li>
<li>A smaller hard drive footprint and faster download/install time than SSMS. Databvase is ~40-56 megs currently, SSMS 2017 is almost a full gigabyte for just the download.</li>
</ul>
<br>
<br>
<b>Why would I use this instead of SSMS/DataGrep/etc?</b>

As stated, this is a hobby project, but it has been found that there are not a lot of DECENT alternatives to SSMS that are not paid for products.  On top of that, most of the free ones that are out there seem to be old. They have older graphics, limited customization or just very few features compared to the likes of SSMS and the others.

That being said, are some of the forseeable reasons why you may want to use this:

<ul>
  <li>You want to include a small SSMS-like application with another application that you install and also have it be still feature rich. </li>
  <li>You have a need for a small SSMS-like application but also want more features than what you'd find in the a lot of the other alternatives</li>
  <li>You want to make use of a data grid with filters, grouping and various printing and exporting features that DevExpress offers but SSMS does not</il>
  <li>You want to be able to customize the look and feel of your query tool with extreme ease.</li>
</ul>
<br>
<br>



<b>Building/Running This Thing</b>

Pretty much all dependencies are either Nuget packages or DevExpress. You will need .NET 4.7 in order to build this and of course run it.  There is currently an installer for it as well, but currently this application is still in heavy development and thus the installer is only being distributed to people who are willing to give the application test spins and provide feedback.



<b>NOTE:</b> Since this uses DevExpress, unfortunately, that means that if you wish to build from the source you will need to have 
DevExpress' libraries installed on your computer. This probably means you will need a license. 

This also uses icons from <a href="http://www.icons8.com">Icons8</a>.

Other dependencies:

<ul>
  <li><a href='https://github.com/jacobslusser/ScintillaNET'>Scintilla.NET</a>- Used for the text editor</li>
<li><a href='https://github.com/Fody/Costura'>Costura/Fody</a>- Used for compressing and packaging the executable</li>
<li><a href='https://github.com/Tyrrrz/Settings'>Tyrrrz.Settings</a>- Used for storing configuration</li>
<li><a href='https://www.newtonsoft.com/json'>Newtonsoft.Json</a>- Used to serialize configuration</li>
<li><a href= 'https://www.nuget.org/packages/Microsoft.SqlServer.Types/'>Micorsoft.SqlServer.Types</a>- Used for SQL Spatial types</li>
<li><a href= 'https://www.nuget.org/packages/Microsoft.SqlServer.SqlManagementObjects'>Microsoft.SqlServer.SqlManagementObjects</a>- Used for much of the SSMS like functionality, especially in the Object Explorer</li>
</ul>

