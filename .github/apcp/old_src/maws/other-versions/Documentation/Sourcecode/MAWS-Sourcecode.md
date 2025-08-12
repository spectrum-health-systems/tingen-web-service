> [MAWS][1] &gt; Sourcecode documentation

<br>
<div align="center">
  <img src="../../.github/Logos/maws-logo-web-service-512x256.png" alt="MAWS logo" width="256">
  <h1> 
    MAWS SOURCODE DOCUMENTATION
  </h1>

  [![REPOSITORY](https://img.shields.io/badge/REPOSITORY-550055?style=for-the-badge)][1]&nbsp;&nbsp;&nbsp;[![MANUAL](https://img.shields.io/badge/MANUAL-550055?style=for-the-badge)][3]&nbsp;&nbsp;&nbsp;[![SOURCECODE-DOCUMENTATION](https://img.shields.io/badge/SOURCECODE%20DOCUMENTATION-8e008e?style=for-the-badge)][2]

</div>
<br>

# About the MAWS sourcecode

This is detailed documentation about the MAWS sourcecode.

Instead of having a ton of comments in the sourcecode, details about the code will be here.

# Headers

## Project


Every class has a standard `**==[ PROJECT ]==**` header thta looks like this:
```
// ========================================[ PROJECT ]=========================================
// MAWS (MyAvatar Web Service Commander)
// Tools and utilities for myAvatar™ custom web services.
// https://github.com/spectrum-health-systems/MAWS
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// ============================================================================================
```

Every class has a unique `**--[ CLASS ]--**` header that looks like this:
```
// -----------------------------------------[ CLASS ]------------------------------------------
// %ClassName%.cs
// %ShortClassDescription%
// %BuildInformation%
// Sourcecode documentation: https://github.com/spectrum-health-systems/MAWSC/blob/main/Documents/Sourcecode/MAWS-Sourcecode.md
// --------------------------------------------------------------------------------------------
```

The entry point for MAWS (*MAWS.asmx.cs*) also has an `**=-[ ABOUT ]-=**` header that provides various information and documentation links related to MAWS. 

# Comments

Attempts have been made to make the MAWS sourcecode as human-readable as possible, so I'm keeping the comments to a minimum. The document you are currently reading is the primary source of information about how everything works.

That being said, you will find the following types of comments in the MAWS sourcecode:
```
/// XML comments used by Visual Studio
```
```
// Additional code description comment
```
```
/* Single-line narrative comment */
```
```
/* Multiple-line  
 * narrative comment  
 */
```

# Variables

## Variable prefixes

* `sent`  
If a variable name starts with "sent" (e.g., `sentValue`), the data it contains original data that should not be modified at any point.

* `work`  
If a variable name starts with "work" (e.g., `workDictionary`), it will be used as a placeholder for modified data. 

* `final`  
If a variable name starts with "final" (e.g., `finalValue`), the data is in it's final form, and is most likely what will be returned from a method.

##  Standard casing/trimming of values

Most logic in MAWS is checked against lowercase values without any leading/trailing whitespace, so (in general) MAWS will reduce a variable to its trimmed, lowercase value. This is done as soon as possible, usually when a variable is declared.

For example, if a variable has a value of "`_AValue_`" (where the "`_`" character is whitespace), it will be converted to "`avalue`". This way if the user has the incorrect casing for a setting called "`EnableAllLogs`", MAWSC will still be able to apply logic because it checks against "`enablealllogs` (which isn't very user friendly).

# Troubleshooting

You can force MAWS to create a data dump file by putting the following line of code anywhere:
```
Logging.DataDump.WriteDump();
```
This will create a data dump logfile in "C:\MAWS\data-dump\", and then exit MAWS gracefully.

# Configuration and settings

*This section needs work*
Default settings are in the .config file.

Some settings are created at runtime.

# Projects

MAWS is comprised of multiple projects:

[MAWS][4]
[MAWS.Configuration][5]
[MAWS.Logging][6]
[MAWS.Session][7]

# Methods

*"Build" vs. "Get"

# Addditional reading

It may be helpful to review the [Creating a Custom Web Service](
https://github.com/myAvatar-Development-Community/document-creating-a-custom-web-service) documentation.

Also, there is quite a bit of myAvatar-related information/documentation at the [myAvatar Development Community](https://github.com/myAvatar-Development-Community/).

<br>

***

> [MAWS][1] &gt; Sourcecode documentation

[1]: https://github.com/spectrum-health-systems/MAWS
[2]: ../Sourcecode/MAWS-Sourcecode.md
[3]: ../Manual/MAWS-Manual.md
[4]: ../Sourcecode/MAWS.md
[5]: ../Sourcecode/MAWS.Common.md
[6]: ../Sourcecode/MAWS.Logging.md
[7]: ../Sourcecode/MAWS.Session.md

<div align="center">
  <sub>
    Last updated July 26th, 2022
  </sub>
<br>