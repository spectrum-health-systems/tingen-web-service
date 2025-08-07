> [MAWS][1] &gt; [Sourcecode documentation][2] &gt; **MAWS.Configuration**

<br>
<br>
<div align="center">
  <img src="../../.github/Logos/maws-logo-web-service-512x256.png" alt="MAWSC logo" width="256">
  <h1> 
    MAWS SOURCODE DOCUMENTATION
  </h1>

  [![REPOSITORY](https://img.shields.io/badge/REPOSITORY-550055?style=for-the-badge)][1]&nbsp;&nbsp;&nbsp;[![MANUAL](https://img.shields.io/badge/MANUAL-550055?style=for-the-badge)][3]&nbsp;&nbsp;&nbsp;[![SOURCECODE-DOCUMENTATION](https://img.shields.io/badge/SOURCECODE%20DOCUMENTATION-8e008e?style=for-the-badge)][2]

</div>

<div align="center">

# **`NAMESPACE`** MAWS.Configuration

</div>

# About this namespace

The MAWS.Configuration namespace contains the logic for configuration files and settings.

# Classes

<details>
<summary>
  <b>MawsSession.cs</b><br>
  <i>Logic for current MAWS session variables.</i>
</summary>

MawsSession.cs contains logic for settings related to a specific MAWS session.

***

### `BuildSessionSettings()`

Build the settings for this MAWS session.

#### Operation

1. Load the default MAWS settings from the local configuration file.


#### Notes

* **\[1]**) These are the settings that won't change when a new session is started, so they are kept static in an external configuration file.
* **\[2]**) We get the date/timestamp at the start of the session, and use the same date/timestamp throughout the session. This way anything related to the specific session will be labeled as such.

</details>

***

<details>
<summary>
  <b>LocalFile.cs</b><br>
  <i>Logic for local MAWS setting files.</i>
</summary>

SettingFiles.cs contains logic for settings related to a specific MAWS session.

***

### `LoadLocalSettings()`

Load the configuration settings from the local configuration file.

#### Operation

None.

#### Notes

* None

</details>

<br>

***

> [MAWS][1] &gt; [Sourcecode documentation][2] &gt; **MAWS.Configuration**

[1]: https://github.com/spectrum-health-systems/MAWS
[2]: ../Sourcecode/MAWS-Sourcecode.md
[3]: ../Manual/MAWS-Manual.md
[4]: ../Sourcecode/MAWS-Sourcecode.md#standard-casingtrimming-of-values

<div align="center">
  <sub>
    Last updated July 14th, 2022
  </sub>
<br>