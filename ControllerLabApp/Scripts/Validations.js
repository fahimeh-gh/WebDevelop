function IsFirstNameEmpty() {
    if (document.getElementById('TxtFName').value == "") {
        return 'FirstName Should not be empty';
    }
    else { return ""; }
}

function IsFirstNameInvalid() {
    if (document.getElementById("TxtFName").value.indexOf("@") != -1) {
        return 'FirstName Should not contain @';
    }
    else { return ""; }
}

function IsLastNameInvalid() {
    if (document.getElementById("TxtLName").value.length >= 5) {
        return 'Last Name should not contain more than 5 character';
    }
    else { return "";}
}
function IsSalaryEmpty() {
    if (document.getElementById("TxtSalary").value == "") {
        return 'Salary should not be empty';
    }
    else { return "";}
}
function IsSalaryInvalid() {
    if (isNaN(document.getElementById("TxtSalary").value)) {
        return 'Enter Valid Salary';
    }
    else { return "";}

}
function IsValid() {
    var FirstNameEmptyMessage = IsFirstNameEmpty();
    var FirstNameInvalidMessage = IsFirstNameInvalid();
    var LastNameInvalidMessage = IsLastNameInvalid();
    var SalaryEmptyMessage = IsSalaryEmpty();
    var SalaryInvalidMessage = IsSalaryInvalid();

    var FinalErrorMessage = "Errors:";
    if (FirstNameEmptyMessage != "")
        FinalErrorMessage += "\n" + FirstNameEmptyMessage;
    if (FirstNameInvalidMessage != "")
        FinalErrorMessage += "\n" + FirstNameInvalidMessage;
    if (LastNameInvalidMessage != "")
        FinalErrorMessage += "\n" + LastNameInvalidMessage;
    if (SalaryEmptyMessage != "")
        FinalErrorMessage += "\n" + SalaryEmptyMessage;
    if (SalaryInvalidMessage != "")
        FinalErrorMessage += "\n" + SalaryInvalidMessage;

    if (FinalErrorMessage != "Errors:") {
        alert(FinalErrorMessage);
        return false;
    }
    else {
        return true;
    }
}