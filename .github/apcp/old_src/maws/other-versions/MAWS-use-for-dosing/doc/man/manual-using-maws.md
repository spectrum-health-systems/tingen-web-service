<!--
  MAWS Manual b210726
-->

<h6 align="center">

  <img src="https://img.shields.io/badge/WARNING:-THIS%20MANUAL%20IS%20A%20WORK%20IN%20PROGRESS!-%23990000?style=for-the-badge">
  
</h6>

***

<h1 align="center">

  <img src="../../resources/asset/img/logo/maws-logo-800x150.png" alt="myAvatar Web Service logo" width="800">
  <br>
  Manual
  <br>

</h1>

<h6 align="center">

  MAWS v0.x&nbsp;&bull;&nbsp;Last updated: January 3rd, 2022

</h6>

***

<h5 align="center">

  [HOME](manual.md)&nbsp;&bull;&nbsp;[HOSTING MAWS](manual-hosting-maws.md)&nbsp;&bull;&nbsp;[IMPORTING MAWS](manual-importing-maws.md)&nbsp;&bull;&nbsp;USING MAWS&nbsp;&bull;&nbsp;[SCRIPTLINK EVENTS](manual-scriptlink-events.md)&nbsp;&bull;&nbsp;[ADDITIONAL INFORMATION](manual-additional-information.md)

</h5>

***

<!-- The HTML indentations have to stay this way to work. -->
<table>
<tr>
<td img src="resources/asset/img/doc/readme/spacer.png" alt="blank-spacer" width="1000" height="1">

  ### CONTENTS
  [OVERVIEW](#using-overview)<br>
  [ABOUT MAWS REQUESTS](#about-maws-requests)<br>
  &nbsp;&nbsp;&nbsp;&nbsp;[EXAMPLES](#examples)<br>
  [ACTIONS AND COMMANDS](#actions-and-commands)<br>
  &nbsp;&nbsp;&nbsp;&nbsp;[ACTIONS ARE CLASSES](#actions-are-classes)<br>
  &nbsp;&nbsp;&nbsp;&nbsp;[COMMANDS ARE METHODS](#commands-are-methods)<br>
  [HOW TO MAKE A MAWS REQUEST](#how-to-make-a-maws-request)<br>
  [MAWS REQUEST RESULTS](#maws-request-results)<br>
  [VALID MAWS REQUESTS](#valid-maws-requests)<br>
  &nbsp;&nbsp;&nbsp;&nbsp;[INPATIENT ADMISSION DATE](#inpatient-admission-date)<br>
  &nbsp;&nbsp;&nbsp;&nbsp;[SUBSCRIBER POLICY NUMBER](#subscriber-policy-number)<br>

</td>
</tr>
</table>

# OVERVIEW
Once you have [hosted](manual-hosting-maws.md) MAWS and [imported](manual-importing-maws.md) it into your myAvatar™ environment, it's ready to use by making a **MAWS Request**.

# ABOUT MAWS REQUESTS
> This document is going to keep things simple. If you are interested in learning about why things are done this way, or would like more "behind the scenes" information, please see [this document](manual-maws-request-behind-the-scenes.md).

A MAWS Request consists of an **action** and a **command**, which tells MAWS what it needs to do, and what information it needs to return.

The components of a MAWS Request are seperated by a "-", and look like this:

`%action%-%command[-option]%`

### MAWS REQUEST EXAMPLES
Here are some examples of MAWS Requests:

* `InptAdmitDate-ComparePreAdmitToAdmit`<br>
Verifies that a client's pre-admission date is the same as the system date. The request **action** is `InptAdmitDate`, and the request **command** is `ComparePreAdmitToAdmit`.

* `Dose-ComparePercentage`<br>
Verifies that the current dose does not exceed a specified percentage. The request **action** is `Dos

# PERFORMING A MAWS REQUEST
To perform an MAWS Request, you'll need to create a ScriptLink event in myAvatar that passes the request and an *OptionObject2015* to MAWS. For more information about creating ScriptLink events, please see the [ScriptLink events](manual-scriptlink-events.md) section of the MAWS Manual.

# MAWS REQUEST RESULTS
A MAWS Request will result in one of the following:

1. Prompt the user to make a change within myAvatar
2. Warn the user about something
3. Optionally return modified data to myAvatar


# NEXT: CREATING SCRIPTLINK EVENTS
Now that you know how MAWS *works*, you can start adding [ScriptLink events](manual-scriptlink-events.md) to your myAvatar™ forms.

***

<h5 align="center">

  [HOME](manual.md)&nbsp;&bull;&nbsp;[HOSTING MAWS](manual-hosting-maws.md)&nbsp;&bull;&nbsp;[IMPORTING MAWS](manual-importing-maws.md)&nbsp;&bull;&nbsp;USING MAWS&nbsp;&bull;&nbsp;[SCRIPTLINK EVENTS](manual-scriptlink-events.md)&nbsp;&bull;&nbsp;[ADDITIONAL INFORMATION](manual-additional-information.md)

</h5>

***