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

<div align="center">

# **`NAMESPACE`** MAWS.Logging

</div>

# About this namespace

Logic for the MAWS logging functionality.

# Classes

<details>
<summary>
  <b>DataDump.cs</b><br>
  <i>Logic for creating data dumps for troubleshooting.</i>
</summary>

***

### `DataDump()`

Create an data dump logfile.

#### Operation

1. Create a data dump message.
2. Verify the "C:/MAWS/Datadump/" directory exists.
3. Write the data dump message to a local file.

#### Notes

* This method is only used for debugging, and should not be used in production.
* You can use this functionality anywhere by placing the line `Logging.DataDump.WriteDump();` where you want the data dump to take place.
* **\[2]** This is a failsafe to make sure that the "C:/MAWS/Datadump/" exists prior to writing to it.
* **\[3]** The logfile is always written to "C:/MAWS/Datadump/"

</details>

***

<details>
<summary>
  <b>LogEvent.cs</b><br>
  <i>Logic for creating data dumps for troubleshooting.</i>
</summary>

***

### `Trace()`

Create a basic tracing log.

#### Operation

1. Write the tracing information to a local file.

#### Notes

* **\[1]** Since tracing logs are pretty simple, and just have basic data, we'll just pass the relevant information to the method that writes the file.

### `Debug()`

Create a basic debug log.

#### Operation

1. Write the debug information to a local file.

#### Notes

* **\[1]** Since debug logs are pretty simple, and just have basic data, we'll just pass the relevant information to the method that writes the file.

### `OptObj()`

Create an OptionObject2015 log.

#### Operation

1. Write the OptionObject2015 information to a local file.

#### Notes

* **\[1]** Since OptionObject2015 logs are pretty simple, and just have basic data, we'll just pass the relevant information to the method that writes the file.

### `ToFile(string logMessage)`

Create a log for something that isn't for an OptionObject.

#### Operation

1. Confirm that a log should be written for this event.
1. If a log should be written, write the logMessage and relevent data to a local file.

#### Notes

* There are two different `ToFile()` methods. This one includes a "logMessage", and is used for anything other than an OptionObject2015 logfile. 

### `ToFile()`

Create a log for an OptionObject.

#### Operation

1. Confirm that a log should be written for this event.
2. If a log should be written, write the OptionObject2015 data to a local file.

#### Notes

* There are two different `ToFile()` methods. This one doesn't include a "logMessage", and is only used for OptionObject2015 logfiles.

### `ConfirmShouldLogEvent()`

Confirm that a specific type of log should be written.

#### Operation

1. Cleanup the logMode setting value (see why [here][4]).
2. If the logMode is set to "all" or  contains the specific log event type (e.g., "trace"), then we should be logging this event.

#### Notes

* **\[2]** Technically we will return "true" if the event should be logged, and "false" if it should not.

### `WriteToFile(string logMessage)`

Create a log for something that isn't for an OptionObject.

#### Operation

1. Write the logMessage and relevent data to a local file.

#### Notes

* There are two different `WriteToFile()` methods. This one includes a "logMessage", and is used for anything other than an OptionObject2015 logfile. 

### `WriteToFile()`

Create a log for an OptionObject.

#### Operation

1. Write the OptionObject2015 data to a local file.

#### Notes

* There are two different `WriteToFile()` methods. This one doesn't include a "logMessage", and is only used for OptionObject2015 logfiles.

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