> [MAWS][1] &gt; [Sourcecode documentation][2] &gt; **MAWS.Logging**

<br>
<br>
<div align="center">
  <img src="../../.github/Logos/maws-logo-web-service-512x256.png" alt="MAWSC logo" width="256">
  <h1> 
    MAWS SOURCODE DOCUMENTATION
  </h1>

  [![REPOSITORY](https://img.shields.io/badge/REPOSITORY-550055?style=for-the-badge)][1]&nbsp;&nbsp;&nbsp;[![MANUAL](https://img.shields.io/badge/MANUAL-550055?style=for-the-badge)][3]&nbsp;&nbsp;&nbsp;[![SOURCECODE-DOCUMENTATION](https://img.shields.io/badge/SOURCECODE%20DOCUMENTATION-8e008e?style=for-the-badge)][2]

</div>

# MAWS.Session

The MAWS.Session project contains logic for the MAWS Session functionality.
<br>
<br>

## MAWS.Session.NewSession

<details>
<summary>
  <b>Initialize.cs</b><br>
  <i>Initialization logic for a new MAWS session.</i>
</summary>

***

### `GetSettings()`

Get the MAWS session configuration settings.

#### Operation

1. Create a list of dictionaries that contain MAWS configuration settings from:
  * the local Web.config file
  * runtime values
2. Combine all of the dictionaries into a single mawsSettings dictionary
4. Log what we did.
5. Return the configuration settings dictionary.

#### Notes

* None.

</details>

<br>

***

## MAWS.Session.Settings

<details>
<summary>
  <b>AtRuntime.cs</b><br>
  <i>Logic for building MAWS session configuration setting components at runtime.</i>
</summary>

***

### `Create()`

Create runtime configuration settings for a MAWS session.

#### Operation

1. Create a new Dictionary<string, string> that initially contains both the datestamp and timestamp when MAWS was executed.

#### Notes

* Other runtime values may be added in the future.

</details>

<br>

<details>
<summary>
  <b>FromExternalSource.cs</b><br>
  <i>LLogic for building MAWS session configuration setting components from external sources.</i>
</summary>

***

### `WebConfigFile()`

Load the configuration settings from the local Web.config file.

#### Operation

1. Create a dictionary containing the configuration settings from the local Web.config file.
2. Return the configuration settings dictionary.

#### Notes

* None

</details>

<br>

***
> [MAWS][1] &gt; [Sourcecode documentation][2] &gt; **MAWS.Logging**

[1]: https://github.com/spectrum-health-systems/MAWS
[2]: ../Sourcecode/MAWS-Sourcecode.md
[3]: ../Manual/MAWS-Manual.md
[4]: ../Sourcecode/MAWS-Sourcecode.md#standard-casingtrimming-of-values

<div align="center">
  <sub>
    Last updated July 6th, 2022
  </sub>
<br>