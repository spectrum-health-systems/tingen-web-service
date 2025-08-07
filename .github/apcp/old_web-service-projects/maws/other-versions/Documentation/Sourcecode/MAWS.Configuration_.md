<!-- b220624.102340 -->

[MAWS](https://github.com/spectrum-health-systems/MAWS) &gt; [Sourcecode](../Sourcecode/MAWS-Sourcecode.md) &gt;  **MAWS.Configuration**

***

<br>

<div align="center">

  <img src="../../.github/Resources/Assets/Logos/maws-logo-web-service-512x256.png" alt="MAWS logo" width="256">
  <h1> 
    SOURCODE DOCUMENTATION
  </h1>

  [![REPOSITORY](https://img.shields.io/badge/REPOSITORY-550055?style=for-the-badge)](https://github.com/spectrum-health-systems/MAWSC)&nbsp;&nbsp;&nbsp;[![MANUAL](https://img.shields.io/badge/MANUAL-550055?style=for-the-badge)](../Manual/MAWSC-Manual.md)&nbsp;&nbsp;&nbsp;[![SOURCECODE-DOCUMENTATION](https://img.shields.io/badge/SOURCECODE%20DOCUMENTATION-8e008e?style=for-the-badge)](MAWSC-Sourcecode.md)

</div>

# `NAMESPACE` MAWS.Configuration
Logic related to configuration files and settings.

There will be more information about how configuration files work here soon.

## `CLASS` MawsSession.cs
Logic for current MAWS session variables.

### `METHOD` Build()
Get MAWS session information.

#### Details
1. Get a nice name for the assembly, and create a trace log.
2. Create a dictionary with the contents of the configuration file
3. Create a dictionary that contains the MAWS Request

#### Notes
* This doesn't return anything (220621).

## `CLASS` SettingsFile.cs
Logic for MAWS configuration files.

### `METHOD` Build()
This is the method description

#### Details
1. Return a dictionary with the following setting values:
    - `MawsMode`
    - `LogMode`
    - `MawsRootDir`
    - `FallbackAvatarUserName`

#### Notes
None.

***

[MAWS](https://github.com/spectrum-health-systems/MAWS) &gt; [Sourcecode](../Sourcecode/MAWS-Sourcecode.md) &gt;  **MAWS.Configuration**