> [MAWS][1] &gt; [Sourcecode documentation][2] &gt; **MAWS namespace**

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

# **`NAMESPACE`** MAWS

</div>

# About this namespace

The MAWS namespace is the entry point for MAWS. When you make a *MAWS Request* via a *ScriptLink event*, this is where that request ends up.

# Classes

<details>
<summary>
  <b>MAWSC.asmx.cs</b><br>
  <i>Methods required by myAvatar</i>
</summary>

***

### `GetVersion()`

Returns the current version of MAWS.

#### Operation

Uh, not much to say here. This method is pretty simple.

#### Notes

* This method is required by myAvatar.
* The version number doesn't change during development. For example, while developing v2.0.x.x, this method will aways return `VERSION 2.0`.
* You can find more information about the `GetVersion()` method [here](https://github.com/myAvatar-Development-Community/document-creating-a-custom-web-service#the-getversion-method).

***

### `RunScript()`

Executes a MAWS Request.

#### Operation

1. Load configuration settings.
2. Setup some nice looking values for some important things.
3. Create and initialize a new OptionObject2015 object that we can work on.
4. Get the MawsMode that will be used.
5. Process the MAWS Request
6. Return an OptionObject2015 object to myAvatar.

#### Notes

* This method is required by myAvatar.
* There is a commented line is at the start of the method that enables troubleshooting logs. This line should remain commented in production.
* You can find more information about the `RunScript()` method [here](https://github.com/myAvatar-Development-Community/document-creating-a-custom-web-service#the-runscript-method).
* **\[2]** You can read more about why we create these values in this way [here][4].
* **\[4]** The MawsMode can be one of the following:
    - `enabled`  
    This is the default setting, which processes MAWS requests normally, returns a modified OptionObject2015 to myAvatar, and logs everything.
    - `disabled`  
    Skip all MAWS functionality. Essentially MAWS will recieve the sentOptObj, then skip directly to finalizing and returning the retOptObj, so no changes are made. This should be used when you don't want myAvatar to call MAWS, but you don't want to disable scripts on every form you use  anything, including writing logs (aside from basic, informational logs).
    - `passthrough`  
    Use MAWS, but don't make changes, only write logs. This is like the "disabled" setting, since no modifications to the OptionObject are make, and also like the "enabled" setting, since MAWS will actually go through the motions and write logs normally.
* **\[6]** The returned OptionObject2015 may - or may not - be modified, depending on the MawsMode and/or the MAWS Request.

</details>

<br>

***

> [MAWS][1] &gt; [Sourcecode documentation][2] &gt; **MAWS namespace**

[1]: https://github.com/spectrum-health-systems/MAWS
[2]: ../Sourcecode/MAWS-Sourcecode.md
[3]: ../Manual/MAWS-Manual.md
[4]: ../Sourcecode/MAWS-Sourcecode.md#standard-casingtrimming-of-values

<div align="center">
  <sub>
    Last updated July 6th, 2022
  </sub>
<br>