This ASP.Net code shows the use of 
* A master page and content pages
* An entry form
* An added class to store the form values
* Session Variables
* Redirects
* Passing information with in a GET string
* Validation controls
The Validation controls in this app will not work unless you alter the config file to add

 <appSettings>
    <add key="ValidationSettings:UnobtrusiveValidationMode" value="None"/>
  </appSettings>

This turns off the default JQuery validation mode.