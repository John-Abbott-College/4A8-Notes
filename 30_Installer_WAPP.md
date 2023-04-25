# Creating an Installer

## Information you need for later

### Determining which architecture your application is built for (x32, x64)

The default architecture in visual studio is `Any CPU`.

![image-20220418101408149](./Images/vs_setting_architecture.png)



* You can select Build -> Configuration Manager to specify what should happen with each of your projects when your app is built on different architectures. 

  

![image-20230424024156495](.\Images\WAPP_Configuration_Manager.JPG)



# Creating an Installer (`setup.exe`)

## Can’t we just copy over the exe?

Beyond the application executable, an application often involves more components

* generic `dll`s, such as `HomeBudget.dll`, `sqlite.dll`
* specific `dll`s to match the processor (64 vs 32 bit), such as `sqlite.Interop.dll`

In addition to the necessary files, there is often the request to add the application to the desktop, and/or the windows menu. Modern installers include ways to update and digitally sign the app files.



## Application executable versus Setup executable versus Microsoft Installer

### Application Executable

When you build your solution or project, it will create an application executable, example: `myApp.exe`

### Setup Executable and `msi` file

You could create a Windows installer you will generate a `setup.exe` and a Microsoft installer `myApp.msi`.

`setup.exe`: 

* an executable that acts as a bootstrapper. It verifies that the the software program can be installed on the computer and then allows the user to interact with the installer. Internally it uses (one or more) `*.msi` file(s).

`msi file`:

* a database that contains the information: 
  * the exe files for the application, 
  * configuration and registry settings, 
  * custom actions, 
  * relevant files, etc

*It is always a good idea to run `setup.exe` and **not** the `*.msi` directly*


* `msi` files allow IT people to create automated installs that bypass the user interaction with the installer.

### Microsoft Installer (`msix` file): 

In 2018, Microsoft introduced the `msix` app packaging format which 

* uninstalls more cleanly (registry changes, files created throughout the system)
* installs the program in a container
* allows you to publish to the Microsoft Store.

![MSIX Package Diagram](.\Images\msixpackage.png)



# Creating an `MSIX` Installer for `HomeBudget`

## Preparation

### Add the UWP option in Visual Studio:

`Tools`->`Get Tools and Features...`

Check the Universal Windows Platform development option:

<img src="./Images/UWP_Option_VS.JPG" />

> 

### Create a `WAPP` project

With the extension installed, create a new **Windows Application Packaging Project** in the ***same solution*** as your application.

<img src="./Images/WAPP_Project.JPG" />



## Windows version:

> You could keep the defaults for the minimum Windows versions to install on. The minimum version limits the features you want to include, for example. You would consider your customer base to make sure to make your application accessible to most.



You may ignore any warning about requiring the Developer Mode for Windows. This is required if you want to publish your application in the Windows Store, which we will not be doing here.



## Application to install

First, we will set the application to install. Select `Dependencies`. right-click to select `Add Project Reference...`

![image-20230417040917029](.\Images\Add_WAPP_Project.JPG)



Select your HomeBudget application. Note that any assemblies the application depends on will be automatically be brought in by the installer.



## Package Configuration

Select the `Package.appx.manifest` file in the project. The manifest allows you to configure the package

![image-20230424015454981](.\Images\WAPP_Package_manifest.JPG)

### Display name

Customize the name you want as the installed application's display name. Describe your app in the description field.



### Icons

In Visual Assets, you will be able to se the Icons for your application. More on this next class.



### Packaging

Leave the unique Id Package name as is.

Set the package display name. A first version of 1.0.0 makes sense.



### Certificate

A signed package gives the user of the package the certainty that the code comes from a trusted source.

You sign your package with your certificate. 

A proper certificate would be a certified trusted certificate. You would need to involve a trusted authority (Comodo, for example) you would pay annually to obtain a code signing certificate. 

Since we are only distributing our application internally (no one we don't know needs to trust us), we will generate a dev certificate. We will not get it authenticated by a trusted authority.



#### Generate a dev certificate

Select `Choose Certificate...` and `Create...`

You could select your Team name as the Publisher Common Name. Choose a password that you will not lose! Create the certificate.

Note that when you View the certificate, `View Full Certificate`, you note that it is indicated that the certificate is not trusted. 

![image-20230424020921468](.\Images\WAPP_dev_certificate.JPG)



The certificate expires in a year. We will "trust it" later. Select OK to create the certificate.  You could select Ok on the warning.

The certificate is now chosen for the installer.

Note that a pfx file that has now been added to the project.

You can now close the manifest file.



## Build the installer

Rebuild your solution.

Note that MSIX allows you to publish your app to the Microsoft Store. We will be creating a local installer instead.

To build the installer, choose `WAPP project -> Publish -> Create App packages...`

We will not be publishing our apps on the Microsoft Store. Keep the `Sideloading` option.

![image-20230424022421100](.\Images\WAPP_Sideloading.JPG)

Click `Next`.

We will use the certificate we created, which should appear.

Click `Next`.

We have to choose which architectures you want to support.  

Choose the location where the installer will be placed. This could be a URL, or a folder. Updates will be checked for in that folder.

Choose `Create`.



#### Configuration Architectures

Note that the creation of the installer fails with errors about mismatches in the architectures. We need to be more specific about how our projects will be built for different architectures. 

Select `Build -> Configuration Manager`. 

Setup the following configurations:

​	Choose Release as the Active solution configuration.

​	Change the Active solution platform to x64. Change all the projects to be built for x64:

​		`Choose Platform -> <New...>`.  In New platform, select x64.

​	Make the same changes for x32. For each project, set x32 as the platform.

![image-20230424025439541](.\Images\WAPP_configuration_projects.JPG)

Regenerate the Installer:

​	`WAPP project -> Publish -> Create App packages...`

In the `Select and configure packages` page, select the x86 and x64 architectures, instead of the generic Neutral:

![image-20230424025234415](.\Images\WAPP_select_architectures.JPG)



Click `Next` and `Create` to create the Installer. This takes some time.

When it is done, a `Finished creating package` dialog will appear:

![image-20230424030748154](.\Images\Wapp_finished_creating_package.JPG)



Clicking on the output location will take you to the installer files.

Note the index.html page that is generated.

Also note that in the installer directory, the msix bundle and the public security certificate appear.

![image-20230424031106894](.\Images\WAPP_installer_certificate.JPG)



Click Copy and Close to have the installer copied to the Installer location. 

You could launch the installer from the html files or the folder.

Note that you are blocked from installing the application.  This is because the certificate is not trusted.

Since you know that you created the certificate you could indicate that you trust the certificate.



#### Trust the dev certificate

Double-click the public certificate file to see that it is your certificate.

Right-click on the .cer file to choose `Install certificate`. 

Choose `Local Machine`

Choose the Certificate store: Trusted Root Certification Authorities



![image-20230424032209019](.\Images\WAPP_Certificate_Store.JPG)





In a company you would have your company's certificate trusted by everyone. If it is not your company's application, you would want to make sure that the certificate is verified by a trusted authority.



You could go to Windows Manage user certificates to delete the certificates when done. 







Follow these instructions to enable secrets on your Github repo:



https://docs.github.com/en/actions/security-guides/encrypted-secrets#creating-encrypted-secrets-for-a-repository

Follow the Actions script instructions to generate secrets for the encoded private key and password.



Only Release configuration.

Set the Wap project directory and path in the env section:

![image-20230424034211147](.\Images\Actions_Wap_env.JPG)















The project includes an Images folder

* Select `Application Folder`

<img src="./Images/vs_installer_view_file_system.png" alt="image-20220418100249789" style="zoom:80%;" />

<img src="./Images/vs_installer_filesystem.png" alt="image-20220418100410989" style="zoom:80%;" />


#### Project Output

* Right-click on the application folder and choose `Add->Project Output`.

<img src="Images/vs_setup_add_project_output.png" alt="image-20220418170838842" style="zoom:80%;" />



 

* In the Project Output Window, 
  * for the project, make sure the one you want installed (the one with your application) is selected.
  * Choose Primary output and select Ok.

<img src="Images/vs_setup_select_primary_output.png" alt="image-20220418171801002" style="zoom:80%;" />


* In addition to the primary output you will see the `dll`s included in your application listed (notice the `System.Data.Sqlite.dll` and the `Budget.dll`)
<img src="Images/vs_setup_list_of_output_files.png" alt="image-20220418173038576" style="zoom:80%;" />

 		

#### Architecture Specific DLLs

**One DLL (`SQLite.Interop.dll`) is missing** since it is in a sub-folder based on the Windows architecture (x64 vs x32).

* Add the `SQLite.Interop.dll` file to the output manually by right-click on the application folder and select `Add->Assembly`

![image-20220418174239854](./Images/vs_setup_add_assembly)





* Navigate to the bin directory of your project, choose `Debug` or `Release` as necessary, and then choose the folder for the correct architecture, either x64 or x32 (see instructions at the beginning of this chapter to determine which architecture is appropriate)

![image-20220418174708646](Images/vs_setup_add_architecture_specific_DLLs.png)

* Select any DLLs you see there (you should see `SQLite.Interop.dll`)
* **NOTE:** it is important to select the correct architecture!



#### Icon

Right-click on the application folder again and choose `Add->File`

Navigate to your application icon (`*.ico`) file and select it as well.



### Desktop Shortcut

* Double-click on the User’s desktop folder. 
* In the empty right panel, right-click and select Create New Shortcut. 

​	<img src="./Images/vs_setup_new_desktop_shortcut.png" style="zoom:80%;" />

* Navigate to the Application Folder and select the primary output, and then click `Ok`

​		![](Images/vs_setup_desktop_shortcut_choosing.png)     ![](Images/vs_setup_desktop_shortcut_select_primary_output.png)

* Rename the shortcut to the name of your application

* Choose the new shortcut, right-click on it and select Properties Window

  <img src="Images/vs_setup_desktop_shortcut_choose_properties.png" alt="image-20220420200456014" style="zoom:80%;" />

* In the properties window, set the icon to the `.ico` file for your application by browsing to and choosing the one you set in the Application Folder.

### Adding a Shortcut to the Start Menu

* Right-click on the User’s Programs Menu folder and choose Add->Folder
* Rename the folder to your company name (could be that of your team). 
  * This will be the folder your application will be installed under when the user installs your application.
* Double-click the new folder. 
* In the empty right panel, right-click and select Create New Shortcut. 
* Navigate to the Application Folder and select the primary output.
* Choose the new shortcut, right-click on it and select Properties Window
* In the properties window, set the icon to the .ico file for your application by browsing and choosing the one you set in the Application Folder.

### Final Touches

If your company name appears as *Default Company Name*, it makes your application look VERY unprofessional.

Configure the following in the properties page of the setup project:

* Choose the Setup project. 
* In the Properties panel set the all of the properties appropriately 



## Build and Test the Installer

* Build the `setup` project (or `build solution`)

	> Note: your application itself needs to build successfully for the installer to be built.

### Verify setup.exe exists

* Open your setup project folder in File Explorer.

* The installer (`setup.exe` and *`YourApplication`*`.msi`) should be available in the `bin` directory

### Install

* Run `setup.exe`

	> To test the installer, you must run `setup.exe` **AS ADMINISTRATOR**. 

* Select  `install for everyone`.
* You could choose all the defaults for the rest to complete the installation. 

#### Validate
* You should see:
  * A desktop shortcut with your icon which launches your application
  * Your company name as a folder in the Start menu with your application in it. 
  * Icons are correct and application can be launched.
  * Your application installed at the location chosen during installation. 
    * All DLLs and application exe are present. 
  * Executable can be run.

