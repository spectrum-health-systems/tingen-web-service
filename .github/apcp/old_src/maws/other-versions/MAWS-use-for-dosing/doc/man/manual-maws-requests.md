
# VALID MAWS REQUESTS

## INPATIENT ADMISSION DATE

#### `InptAdmitDate-VerifyPreAdmitDate`

**What it does**<br>
Verifies that the Inpatient Admission Date is the same as the system current date.

**How it works**<br>
* When a completed Admission form is submitted, we check to if the "Admission Type" is "Pre-Admission"
* If the "Admission Type" is set to  "Pre-Admission" and the "Pre-Admission Date" is not the same as the system date, a pop-up will notify the user that they need to modify the Pre-Admission Date field  to equal the system time, and the user will be returned to the form to modify the Pre-Admission Date
* If the "Admission Type" is not set to "Pre-Admission", or if it is and the Pre-Admission Date is the same as the system date, the form is submitted normally

## SUBSCRIBER POLICY NUMBER

#### `SubPolicyNumber-TrimWhitespace`

**What it does**<br>
TBD.

**How it works**<br>
* TBD
* TBD
* TBD