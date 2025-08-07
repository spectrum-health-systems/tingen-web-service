# Changelog

# v0.60.0.0-YYMMDD
* `INFO` No date on these because there has been alot of development I haven't documented, since it has mostly been code/comment cleanup.

# v0.52.0.0-220116
* `MODIFY` Dose.Compare.cs refactor
* `MODIFY` TheOptionObject.Finalize.cs refactor

# v0.51.0.0-220116
* `INFO` New version system
* `MODIFY` Dose.Compare.cs refactor

# v0.28.22015.2329 (2022-01-15)
* `FIX` Dose.cs had the old "Logging" configuration setting instead of "LogSetting"

# v0.28.22015.2319 (2022-01-15)
* `INFO` Code and comment cleanup/refactoring
* `FIX` Still working on getting the new logging system to work correctly.

# v0.28.22015.2244 (2022-01-15)
* `INFO` Code and comment cleanup/refactoring
* `FIX` Logs weren't being written because the username wasn't being passed.
* `REMOVE` InptAdmitDate project
* `REMOVE` NewDevelopment project

# v0.27.22011.1435 (2022-01-12)
* `INFO` Code and comment cleanup/refactoring
* `ADD` Logfiles now have a development string at the end
* `ADD` You can put a Xms pause between writing logfiles

# v0.26.22011.2136 (2022-01-11)
* `INFO` Code and comment cleanup/refactoring
* `ADD` Logfiles are now written to the "Logs/<username>/logfile.mawslog"

# v0.26.22011.2039 (2022-01-11)
* `INFO` Code and comment cleanup
* `MODIFY` RequestSyntaxEngine.RequestComponent.cs refactor
* `MODIFY` RequestSyntaxEngine.TestFunctionality.cs refactor

# v0.26.22011.2012 (2022-01-11)
* `INFO` Code and comment cleanup
* `MODIFY` MyAvatoolWebService.cs refactor

# v0.26.22011.1806 (2022-01-11)
* `INFO` Test build
* `ADD` Dose.Compare only executes when the orderType is "Recurring"

# v0.25.22011.1722 (2022-01-11)
* `INFO` Test build
* `FIX` Percentage logic was incorrect
* `FIX` currentDose was sending an error when it should not have
* `MODIFY` Modify error messages

# v0.25.22010.2222 (2022-01-10)
* `INFO` Test build
* `MODIFY` Framework for missing dosage

# v0.25.22010.2207 (2022-01-10)
* `INFO` Test build
* `ADD` Warning when a previous dose doesn't exist.
* `FIX` Previous/current dose percentage logic was incorrect.

# v0.25.22010.2013 (2022-01-10)
* `INFO` Test build
* `MODIFY` Reduced time between writing same-name log files from 500ms to 100ms
* `ADD` 100ms pause between writing logfiles

# v0.25.22010.2008 (2022-01-10)
* `INFO` Test build
* `MODIFY` Increased time between writing same-name log files from 100ms to 500ms

# v0.25.22010.2001 (2022-01-10)
* `INFO` Test build
* `MODIFY` ADD a "Process complete" log event

# v0.25.22010.1949 (2022-01-10)
* `INFO` Test build
* `MODIFY` Changed logfile timestamp from "ffff" to "fffffff"

# v0.25.220110.1936 (2022-01-10)
* `INFO` Test build
* `MODIFY` REMOVE "-{callerMemberName}" from logfile name

# v0.25.22010.1825 (2022-01-10)
* `INFO` Test build
* `MODIFY` ADD "-{callerLineNumber}" to logfile name
* `MODIFY` Changed logfile timestamp from "fff" to "ffff"

# vv0.25.22010.1751 (2022-01-10)
* `INFO` Test build
* `MODIFY` Logging changes (additional logging, MODIFY syntax) for testing purposes.
* `MODIFY` UPDATE AssemblyInfo files so all project versions match.
* `MODIFY` REMOVE newline in warning message for dosing percentage

# v0.24.22007.1516 (2022-01-07)
* `INFO` Repository documentation updates

# v0.22.22005.1906 (2022-01-05)
* `INFO` Test build

# v0.21.22005.1914 (2022-01-05)
* `INFO` Test build

# v0.20.220103.HHMM (2022-01-03)

* `INFO` Repository documentation updates

# v0.20.220103.HHMM (2022-01-03)

* `INFO` Repository documentation updates

# 0.19.21312.1509 (2021-11-08)

* `MODIFY` Utility.AppSettings.cs -> Utility.ExternalConfiguration.cs
* `MODIFY` Config file is now sent as a filePath instead of a fileName, which will allow for more customization as to where the configuration file goes.

# v0.18.21307.1444 (2021-11-04)

* `INFO` Sourcecode comment updates

# v0.17.21306.1200 (2021-11-03)

* `INFO` Repository documentation updates

# v0.16.21207.1456 (2021-07-26)

* `INFO` Manual updates.

# v0.16.21200.2031 (2021-07-19)

* `INFO` Code and comment cleanup.

# v0.16.21200.1750 (2021-07-19)

* `INFO` Code and comment cleanup.
* `MODIFY` **Dose:** The entire lastOrderScheduled text is parsed, instead of a specific line.
* `MODIFY` **Dose:** RENAME lastOrderScheduled -> lastOrderSchedule
* `REMOVE` **NewDevelopment:** Settings.cs
* `REMOVE` **TheOptionObject:** Settings.cs
* `FIX` **Utility:** The AppSettings class wasn't wrapped in a namespace.

# v0.15.21200.1703 (2021-07-19)

* `INFO` **Dose:** Dose.Compare.Percentage() works!

# v0.15.21200.1632 - 0.15.21200.1639 (2021-07-19)

* `INFO` Clean build for testing.

# v0.15.21200.1627 (2021-07-19)

* `INFO` Clean build for testing.
* `ADD` **Dose:** formLoopCount and fieldLoopCount for debugging purposes.

# v0.15.21200.1537 (2021-07-19)

* `INFO` Clean build for testing.

# v0.15.21200.1526 (2021-07-19)

* `INFO` Clean build for testing.
* `FIX` Putting the AssemblyVersion in the logfile contents was causing an issued. Roadmapped.

# v0.15.21200.1526 (2021-07-19)

* `INFO` Clean build for testing.

# v0.15.21200.1509 (2021-07-19)

* `INFO` Clean build for testing.
* `FIX` *.settings* files were not RENAME to *.conf* in the sourcecode. Duh.

# v0.15.21200.1455 (2021-07-19)

* `INFO` Clean build for testing.
* `ADD` AppData/Configuration/
* `MODIFY` **Utility:** WriteToFile() -> WriteTimestampedFile()

# v0.15.21200.1324 - v0.15.21200.1344 (2021-07-19)

* `INFO` A test for comment length (not project related)

# v0.15.21200.1316 (2021-07-19)

* `INFO` Code/comment cleanup
* `MODIFY` Setting file extension is now *.conf*, since *.settings* was causing an issue with Visual Studio thinking it was a settings file.
* `ADD` AppData/Configuration/

# v0.15.21196.1319 (2021-07-15)

* `INFO` Code/comment cleanup
* `ADD` AppData/
* `ADD` AppData/Logs/

# v0.15.21190.1333 (2021-07-09)

* `REMOVE` Logger project
* `REMOVE` Test project
* `REMOVE` MyAvatoolWebService.Settings.cs
* `MODIFY` **Dose:** Percentages are now calculated as doubles.
* `MODIFY` **Utility:** AppSettings.FromKeyValuePair() paramater changed to fileName, this way we can force the path to be either the production or staging folder.

# v0.15.21189.2018 (2021-07-08)

* `INFO` Clean build for testing.

# v0.15.21189.1853 (2021-07-08)

* `INFO` Clean build for testing.
* `ADD` Basic Dose command functionality
* `MODIFY` RENAME Dose.Verify.cs -> Dose.Compare.cs
* `ADD` Settings for verifying dose information

# v0.15.21189.1822 (2021-07-08)

* `INFO` Initial v0.15 version.
* `INFO` Archived v0.14.

# v0.14.21189.1822 (2021-07-08)

* `INFO` Final v0.14

# v0.14.21189.1809 (2021-07-08)

* `INFO` Clean build for testing.

# v0.14.21189.1758 (2021-07-08)

* `INFO` Clean build for testing.

# v0.14.21189.1623 (2021-07-08)

* `INFO` Clean build for testing.

# v0.14.21189.1622 (2021-07-08)

* `INFO` Code/comment/documentation cleanup.
* `MODIFY` **Utility:** AppSettings.FromKeyValuePair() now allows .settings files to have blank lines.
* `MODIFY` **Utility:** LogEvent.WriteToFile() filename changed to make it easier to look at things in chronological order.

# v0.14.21189.1423 (2021-07-08)

* `INFO` Code/comment/documentation cleanup.
* `ADD` **Utility:** Setting.cs
* `MODIFY` **Utility:** Started migrating LogEvent code
* `MODIFY` Logger.cs -> Utility.cs
* `REMOVE` **Dose:** Verify.Percentage_Testing.cs
* `REMOVE` **Dose:**Setting.cs (funcationality moved to Utility.AppSettings.cs)
* `REMOVE` **InptAdmtDate:** Compare.PreAdmitToAdmit_Testing.cs
* `REMOVE` **InptAdmtDate:** Setting.cs (funcationality moved to Utility.AppSettings.cs)

# v0.14.21188.1607 (2021-07-07)

* `WARN` This version doesn't work, I'm halfway through updating the logging functionality.
* `INFO` Code/comment/documentation cleanup.
* `ADD` **Logger:** LogEvent.cs
* `ADD` **Logger:** LogEvent.Timestamped()
* `REMOVE` **Logger:** Timestamped.cs, functionality moved to Logger.LogEvent.cs
* `MODIFY` **Logger:** Started migrating LogEvent code
* `MODIFY` Moved the stand-alone testing logic out of GetVersion(), and put it in it's own method. Now there is a single `//TestFunctionality()' line that is commented out by default, since it actually breaks MAWS in production.

# v0.14.21188.1355 (2021-07-07)

* `INFO` Initial v0.14 version.
* `INFO` Archived v0.13.
* `INFO` Archived v0.12.
* `INFO` Archived v0.11.
* `INFO` Archived v0.10.
* `INFO` Cleaned up dev/ archives.

# v0.13.21187.2038 (2021-07-06)

* `INFO` Clean build for testing.
* `MODIFY` REMOVE custom lines in GetVersion().
* `MODIFY` FIX a few log comments.

# v0.12.21183.1411 (2021-07-02)

* `INFO` Final 0.12 version deployed to production for testing.
* `MODIFY` Confirmed all projects are set to v0.12.21183.1411 

# v0.12.21183.0048 (2021-07-01)

* `INFO` Code/comment/documentation updates/cleanup
* `ADD` Test case to the switch statement in RunScript()

## RequestSyntaxEngine

* `MODIFY` Logging functionality brought up to other project levels
* `REMOVE` ParseRequest.cs

## NewDevelopment (previously TestFunctionality)

* `ADD` Execute.cs
* `ADD` Execute.Action()
* `ADD` Settings.cs
* `ADD` Settings.GetSettings()
* `REMOVE` Existing.cs
* `REMOVE` New.cs

# v0.12.21182.2257 (2021-07-01)

* `INFO` Code/comment/documentation updates/cleanup
* `ADD` **Dose:** .licenseheader file
* `ADD` **InptAdmitDate:** .licenseheader file
* `ADD` **TestFunctionality:** .licenseheader file

# v0.12.21182.1839 (2021-07-01)

* `ADD` **InptAdmitDate:** Compare.cs
* `ADD` **InptAdmitDate:** Compare.PreAdmitToAdmit()
* `ADD` **InptAdmitDate:** Execute.cs
* `ADD` **InptAdmitDate:** Execute.Action()
* `ADD` **InptAdmitDate:** Settings.cs
* `ADD` **InptAdmitDate:** Settings.GetSettings()
* `ADD` **Logger:** Logfiles now have the .mawslog extension
* `ADD` **Dose:** Exectute.cs
* `ADD` **Dose:** Exectute.Action()
* `ADD` **Dose:** Settings.cs
* `ADD` **Dose:** Settings.GetSettings()
* `ADD` **Dose:** Verify.cs
* `ADD` **Dose:** Verify.Percentage()
* `ADD` **Dose:** Verify.Percentage_Testing()
* `REMOVE` Command project
* `REMOVE` MyAvatoolWebService.Dose.cs

# v0.12.21182.1554 (2021-07-01)

* `INFO` **Logger:** You can now specifiy what type of events are logged.
* `ADD` **Logger:** Logger.LogEvent().
* `MODIFY` **Logger:** Logging functionality for MyAvatoolWebService project.
* `MODIFY` **Logger:** Log filenames and syntax.
* `ADD` Dose project.
* `ADD` InptAdmitDate project.

# v0.11.21181.1709 (2021-06-30)

* `INFO` Final v0.11 version deployed to production for testing
* `ADD` New project: Command.csproj
* `ADD` New project: TheOptionObject.csproj
* `ADD` **Command:** InptAdmitDate.cs
* `ADD` **Command:** InptAdmitDate.ExecuteAction()
* `ADD` **Command:** InptAdmitDate.ComparePreAdmitToAdmit()
* `ADD` **Command:** InptAdmitDate.ComparePreAdmitToAdmit_Testing()
* `ADD` **Command:** TestFunctionality()
* `ADD` **Command:** TestFunctionality.ForceInptAdmitDate()
* `ADD` **Logger:** 10,000/sec to the filename.
* `ADD` **Logger:** 10ms pause after writing a file.
* `ADD` **Test:** Existing.cs
* `ADD` **Test:** New.cs
* `ADD` **TheOptionObject:** Finalize.cs
* `ADD` **TheOptionObject:** Finalize.WhichComponents()
* `ADD` **TheOptionObject:** Finalize.RequiredFields()
* `ADD` **TheOptionObject:** Finalize.RecommendedFields()
* `ADD` **TheOptionObject:** Finalize.NonRecommendedFields()
* `MODIFY` **Logger:** Logger filename is more descriptive.
* `MODIFY` Moved Test project to src/
* `REMOVE` **Logger:** *verboseLog* parameter. In roadmap.

# v0.11.21181.1407 (2021-06-30)

* `INFO` Code/comment/documentation updates/cleanup
* `MODIFY` Moved Logger project to src/
* `FIX` Project references.
* `ADD` New project: Test.csproj
* `ADD` *licenseheader* files
* `ADD` **Logger:** *verboseLog* parameter
* `ADD` **Test:** Existing.cs
* `ADD` **Test:** Existing.Force()
* `REMOVE` Testing.cs

# v0.11.21181.1305 (2021-06-30)

* `INFO` Code/comment/documentation updates/cleanup
* `MODIFY` **Logger:** Timestamped.WriteToFile(): *logMessage* is now an optional parameter, and defaults to "No log message defined".
* `MODIFY` **Logger:** Minor changes to log output text.
* `MODIFY` **Logger:** RENAME the "Caller" parameters to be more descriptive.

# v0.11.21179.1755 (2021-06-28)

* `INFO` Groundwork for framework update
* `MODIFY` Lots of logging updates
* `ADD` New project: Dose.csproj
* `ADD` New project: Logger.csproj
* `ADD` New project: InptAdmitDate.csproj
* `ADD` New project: RequestSyntaxEngine.csproj
* `ADD` **Logger:** Timestamped.cs
* `ADD` **Logger:** Timestamped.Maintenance()
* `ADD` **Logger:** Timestamped.WriteToFile()
* `ADD` **RequestSyntaxEngine:** ParseRequest.cs
* `ADD` **RequestSyntaxEngine:** ParseRequest.ExecuteCommand()
* `ADD` **RequestSyntaxEngine:** RequestComponent.cs
* `ADD` **RequestSyntaxEngine:** RequestComponent.GetCommand()
* `ADD` **RequestSyntaxEngine:** RequestComponent.GetAction()
* `ADD` **RequestSyntaxEngine:** RequestComponent.GetOption()
* `ADD` **RequestSyntaxEngine:** TestFunctionality.cs
* `ADD` **RequestSyntaxEngine:** TestFunctionality.Force()
* `REMOVE` Maintenance.cs
* `REMOVE` Logger.cs

# v0.10.21176.1652 (2021-06-25)

* `INFO` Code/comment/documentation updates/cleanup
* `FIX` A completed OptionObject wasn't being passed back to Avatar.

# v0.10.21176.1518 (2021-06-25)

* `INFO` Code/comment/documentation updates/cleanup
* `ADD` Settings.cs
* `ADD` Settings.GetSettings()
* `ADD` Settings are now loaded from an external file
* `ADD` "TestFunctionality" setting
* `MODIFY` \MAWS\Log -> \MAWS\Logs
* `MODIFY` Testing.Force() -> Testing.Functionality()

# v0.9.21179.1515 (2021-06-28)

* `FIX` FIX returning the OptionObject.

# v0.9.21179.1312 (2021-06-28)

* `ADD` ADD Dose in switch statement, for testing Dose functionlity.

# v0.9.21176.0200 (2021-06-25)

* `INFO` Final v0.9 release. FIX a few things that impacted deployment.

# v0.9.21172.1617 (2021-06-21)

* `INFO` Final v0.9 release (not the case, see above)

# v0.9.21172.1316 (2021-06-21)

* `INFO` Code/comment/documentation updates/cleanup
* `REMOVE` MyAvatoolWebService.ForceTest()
* `ADD` Testing.cs
* `ADD` Testing.Force()
* `MODIFY` MAWS Request commands/actions/options are now converted to lowercase prior to being returned by RequestSyntaxEngine.cs
* `MODIFY` Maintenance.ConfirmLogDirectory() -> Maintenance.ConfirmLogDirectory()

# v0.9.21172.1210 (2021-06-21)

* `INFO` Code/comment/documentation updates/cleanup

# v0.9.21171.1735 (2021-06-20)

* `MODIFY` ADD [DEBUG] prefix to log files
* `MODIFY` ADD [SYSTEM] prefix to log files

# v0.9.21171.1731 (2021-06-20)

* `ADD` Error logging for invalid commands
* `ADD` Error logging for invalid InptAdmitDate.cs actions
* `ADD` Error logging for invalid Dose.cs actions

# v0.9.21171.1719 (2021-06-20)

* `INFO` Code/comment cleanup (lots of undocumented changes to *InpatientAdmissionDate* to bring it in-line with the new framwork)
* `MODIFY` RENAME *InpatientAdmissionDate* -> *InptAdmitDate*
* `MODIFY` REMOVE *GetRequestAction()* and *GetRequestOption()* from *MyAvatoolWebService.asmx.cs* so the scope is tightened up a bit.
* `ADD` /Resources/Log/
* `ADD` Maintenance.cs
* `ADD` Maintenance.CreateLogDirectory()
* `ADD` Logger.cs
* `ADD` Logger.WriteToTimestampedFile()
* `ADD` Dose.cs
* `ADD` Dose.ForceTest()
* `ADD` Dose.VerifyPercentage()
* `ADD` Dose.VerifyPercentage_Testing()
* `MODIFY` Convert actions/options to lowercase

# v0.9.21170.2311 (2021-06-19)

* `INFO` Re-implemented the *InpatientAdmissionDate* command
* `ADD` InpatientAdmissionDate.cs
* `ADD` RequestSyntaxEngine.ForceTest()

# v0.9.21170.2044 (2021-06-19)

* `INFO` Built-in (simplistic!) testing works.
* `ADD` MyAvatoolWebService.ForceTest()
* `ADD` RequestSyntaxEngine.ForceTest()

# v0.9.21170.1739 (2021-06-19)

* `INFO` Documentation updates

# v0.9.21170.1726 (2021-06-19)

* `INFO` Documentation updates
* `MODIFY` Started the change to the MAWS Request Syntax Engine

# v0.9.21170.1628 (2021-06-19)

* `INFO` Code/comment/documentation changes

# v0.9.21161.1940 (2021-06-10)

* `ADD` OptionObjectMaintenance.cs
* `ADD` OptionObjectMaintenance.FinalizeObject()
* `ADD` OptionObjectMaintenance.FinalizeRequiredFields()
* `ADD` OptionObjectMaintenance.FinalizeNonRequiredFields()

# v0.9.21161.1854 (2021-06-10)

* `INFO` Code and comment cleanup

# v0.9.21161.1834 (2021-06-10)

* `INFO` Version refresh

# v0.9.21161.1831 (2021-06-10)

* `ADD` MyAvatoolWebService.GetVersion()
* `ADD` MyAvatoolWebService.RunScript()
* `ADD` MyAvatoolWebService.MethodName()

# v0.9.21161.1816 (2021-06-10)

* `INFO` ADD the NTST.ScriptLinkService.Objects project to the solution
* `MODIFY` MAWS Manual updates

# v0.9.21161.1749 (2021-06-10)

* `INFO` Framework commit

# v0.8.21111.1535 (2021-04-21)

* `ADD` /Resources/Dev/sourcecode-information.md
* `RENAME` /Resources/Dev/current-versions.md -> /Resources/Dev/developent-information.md

# v0.8.21111.1434 (2021-04-21)

* `ADD` /Resources/Dev/current-versions.md

# v0.7

* `INFO` Update documentation/comments.

># v0.6

* `INFO` Update documentation/comments.

# v0.5

* `INFO` Update documentation/comments.

# v0.4

* `INFO` Update documentation/comments.

# v0.3

* `INFO` Update documentation/comments.

# v0.2.21014.1544 (2021-01-14)

* `ADD` OptionObjectMaintenance.cs
* `ADD` OptionObjectMaintenance.Complete()
* `ADD` OptionObjectMaintenance.CompleteRequired()
* `ADD` OptionObjectMaintenance.CompleteRecommended()
* `ADD` OptionObjectMaintenance.CompleteNotRecommended()
* `ADD` Functionality to InptAdminDate.VerifyPreAdmitDate() so once the "typeOfAdmissionField" and "preAdmitToAdmissionDateField" fields are found, MAWS stops looking through the sentOptionObject2. This should speed things up in some cases.
* `MODIFY` Refactored detailed error messages in InptAdminDate.VerifyPreAdmitDate() with string interpolation.

# v0.2.21014.1544 (2021-01-14)

* `ADD` InptAdminDate.Parser() method
* `ADD` InptAdminDate.VerifyPreAdmitDate() method
* `MODIFY` Requests in the RunScript() method now uses "workingOptionObject2" instead of "completedOptionObject2" because I want to make sure it's very clear as to what MAWS is sent ("sentOptionObject2"), what it works with ("workingOptionObject2"), and what it returns to myAvatar ("completedOptionObject2").
* `RENAME` "InptAdminDate.cs" to "InptAdmitDate.cs" because this request will do things with the inpatient *admission* date, and the "Admin" abbreviation indicates *administration*.
* `RENAME` "action" to "mawsRequest" because going forward ScriptLink events will be passing a "request-action" (e.g., "InptAdmitDate-VerifyPreAdmitDate")
* `UPDATE` Documentation

# v0.2.21014.1425 (2021-01-14)

* `REMOVE` Local methods to pre-process an action (i.e., "MyAvatoolWebService.asmx.cs.InptAdminDate"). The pre-processing is now going to be done in the action class, in a method named "Parser()" (e.g., "InptAdminDate.Parser()").
* `UPDATE` Documentation

# v0.2.21013.1802 (2021-01-13)

* `ADD` InptAdminDate.cs class.
* `MODIFY` RENAME "MyAvatoolWebService.asmx.cs.MethodName()" to "MyAvatoolWebService.asmx.cs.InptAdminDate()".
* `MODIFY` ADD "InptAdminDate" case to the switch statement in RunScript().
* `MODIFY` ADD "SubPolicyNumber" case to the switch statement in RunScript().

# v0.1.21013.1420 - 0.1.21013.1712 (2021-01-13)

* `ADD` MAWS.licenseheader file for use with the [License Header Manager](https://marketplace.visualstudio.com/items?itemName=StefanWenig.LicenseHeaderManager) extension.
* `MODIFY` AssemblyInfo.cs with...uh...assembly information.
* `MODIFY` RENAME *sentOptionObject* to *sentOptionObject2* so it's more inline with Netsmart's (wierd) naming conventions.
* `ADD` MAWS.licenseheader file for use with the [License Header Manager](https://marketplace.visualstudio.com/items?itemName=StefanWenig.LicenseHeaderManager) extension.
* `MODIFY` AssemblyInfo.cs with...uh...assembly information.
* `MODIFY` RENAME *sentOptionObject* to *sentOptionObject2* so it's more inline with Netsmart's (wierd) naming conventions.

# v0.0.0.0 (2021-01-12)

* `INFO` This is a blank MAWS template (built following the steps in the MAWS [manual](doc/man/manual-custom-myavatar-web-services.))