<!-- u250130 -->

<div align="center">

  ![logo](/.github/image/logo/TingenWebService_logo_320x568.png)

</div>

# The Tingen Web Service

[Netsmart's Avatar™](https://www.ntst.com/Solutions-and-Services/Offerings/myAvatar) is a behavioral health EHR that offers a recovery-focused suite of solutions that leverage real-time analytics and clinical decision support to drive value-based care.

While Avatar™ is a robust platform, it isn't perfect. The good news is that you can extend myAvatar™ functionality via Netsmart's Avatar™ Web Services, and/or custom web services that are written by other Avatar™ users.

**Tingen** is one such custom web service which includes various tools and utilities for Avatar™ that aren't included in the official release, and provides a solid foundation for building additional functionality quickly and efficiently.

## Tingen features

* Several built-in tools and utilities that extend the functionality of Avatar™
* A solid foundation to build additional Avatar™ custom tools and utilities
* Extremely customizable
* Robust logging
* ...and [more](https://github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Static/TingenFeatures.md)!

# Tingen development

The Tingen web service is actually two components:

<div align="center">
		<table>
		<tr>
			<td>
				<a HREF="https://github.com/spectrum-health-systems/Tingen-Development"><img src="https://github.com/spectrum-health-systems/Tingen-Development/blob/main/.github/image/logo/TingenDevelopment_logo_194x254.png"></a>
			</td>
      <td>
				<a HREF="https://github.com/spectrum-health-systems/Outpost31"><img src="https://github.com/spectrum-health-systems/Outpost31/blob/main/.github/image/logo/Outpost31_logo_194x254.png"></a>
			</td>
		</tr>
    <tr>
			<td align="center">
				The Tingen <b>front end</b>
			</td>
      <td align="center">
				The Tingen <b>back end</b>
			</td>
		</tr>
	</table>
</div>

And they work like this:

```mermaid
flowchart LR
Input(Input) -.-> Tingen(Tingen) --> Outpost31(Outpost31) -.-> Output(Output)
style Input color:#6A6A6A,fill:#444444
style Tingen color:#000000,fill:#ff9800,stroke:#4caf50,stroke-width:3px
style Outpost31 color:#000000,fill:#ff9800,stroke:#4caf50,stroke-width:3px
style Output color:#6A6A6A,fill:#444444
```

# Tingen releases

When a new Tingen release is ready, Tingen_development and Outpost31 are compiled into:

<div align="center">
		<table>
		<tr>
			<td>
				<a HREF="https://github.com/spectrum-health-systems/Tingen"><img src="https://github.com/spectrum-health-systems/Tingen/blob/main/.github/image/logo/Tingen_logo_194x254.png"></a>
			</td>
      </tr>
      <tr>
      <td align="center">
				<b>The Tingen web service!</b>
			</td>
		</tr>
	</table>
</div>

And they work like this:

```mermaid
flowchart LR
Avatar(Avatar) -- Request --> Tingen(Tingen) -- Reply --> Avatar
style Avatar color:#000000,fill:#1b8eb7,stroke:#FFFFFF,stroke-width:2px
style Tingen color:#000000,fill:#ff9800,stroke:#4caf50,stroke-width:3px
```

## Development releases

Tingen/Outpost31 **development** is done using [Tingen-Development](https://github.com/spectrum-health-systems/Tingen-Development) and [Outpost31](https://github.com/spectrum-health-systems/Outpost31).

<div align="center">
		<table>
		<tr>
			<td>
				<a HREF="https://github.com/spectrum-health-systems/Tingen-Development"><img src="https://github.com/spectrum-health-systems/Tingen-Development/blob/main/.github/image/logo/TingenDevelopment_logo_194x254.png"></a>
        <a HREF="https://github.com/spectrum-health-systems/Outpost31"><img src="https://github.com/spectrum-health-systems/Outpost31/blob/main/.github/image/logo/Outpost31_logo_194x254.png"></a>
			</td>
		</tr>
	</table>
</div>

Development releases may be broken and not fully tested, and should not be used in production environments.

## Stable releases

Once the development version of Tingen has been tested and verified to be **stable**, Tingen and Outpost31 are compiled into [Tingen](https://github.com/spectrum-health-systems/Tingen).


<div align="center">
	<table>
		<tr>
			<td>
				<a HREF="https://github.com/spectrum-health-systems/Tingen"><img src="https://github.com/spectrum-health-systems/Tingen/blob/main/.github/image/logo/Tingen_logo_194x254.png"></a>
			</td>
		</tr>
	</table>
</div>

Stable releases are not intended for production environments outside of Spectrum Health Systems. Use at your own risk!

### Community releases

Once a stable release has been in production at Spectrum Health Systems for a few months, it is released as the Tingen **Community Release**.

<div align="center">
	<table>
		<tr>
			<td>
				<a HREF="https://github.com/spectrum-health-systems/Tingen-CommunityRelease"><img src="https://github.com/spectrum-health-systems/Tingen-CommunityRelease/blob/main/.github/image/logo/TingenCommunityRelease_logo_194x254.png"></a>
			</td>
		</tr>
	</table>
</div>


# Tingen utilities




For more infomation about Tingen, please read the [documentation](https://github.com/spectrum-health-systems/Tingen-Documentation).

# Tingen components

The Tingen web service is actually two parts:




# Tingen components

# Repository branches

There are three two types of branches in this repository:

* **[main](https://github.com/spectrum-health-systems/Tingen/tree/main)**  
  This is the latest stable release of Tingen. You can think of this as the Release Candidate for the Tingen [Community Release](https://github.com/spectrum-health-systems/Tingen-CommunityRelease).

* **Tingen archive snapshots**  
  When development starts on a new monthly version, the previous version is archived to a separate branch (e.g., `24.9.0-stable`).

# Roadmaps and Changelogs

You can also review the Tingen [Roadmap](https://github.com/orgs/spectrum-health-systems/projects/51/views/3) and [Changelog](https://github.com/orgs/spectrum-health-systems/projects/51/views/4?groupedBy%5BcolumnId%5D=141162315&filterQuery=status%3ACompleted).

Remember, though, that the majority of the upcoming features/changes will be part of [Outpost31](https://github.com/spectrum-health-systems/Outpost31).

## Other projects

The reason why this repository is pretty bare-bones is because all of the development work is really done in 

* [**Tingen_development**](https://github.com/spectrum-health-systems/Tingen_development)  
  The development version of Tingen

* [**Outpost31**](https://github.com/spectrum-health-systems/Outpost31)  
  The core components/logic of Tingen

# Documentation

You can find all the documentation you could ever want about Tingen (and related projects) [here](https://github.com/spectrum-health-systems/Tingen-Documentation).
