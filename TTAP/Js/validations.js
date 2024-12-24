// Validations JScript File
function NumberhyphenOnly() {
    var AsciiValue = event.keyCode
    if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127) || (AsciiValue == 45) || (AsciiValue == 47))
        event.returnValue = true;
    else {
        event.returnValue = false;

        alert("Enter NumericValues, '/', '-' Only");
    }
}


function Dates() {
    var AsciiValue = event.keyCode
    if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127) || (AsciiValue == 45) || (AsciiValue == 46) || (AsciiValue == 47))
        event.returnValue = true;
    else {
        event.returnValue = false;

        alert("Enter Date Format(DD-MM-yyyy). Use Only Numbers, '.', '/', '-' Only");
    }
}

function NumberCharandHypehn() {
    var AsciiValue = event.keyCode
    if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue == 8 || AsciiValue == 127) || (AsciiValue == 45) || (AsciiValue == 47) || (AsciiValue == 46) || (AsciiValue == 32))
        event.returnValue = true;
    else {
        event.returnValue = false;

        alert("Enter NumericValues, '/', '-' Only");
    }

}

function NumberOnly() {
    var AsciiValue = event.keyCode
    if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
        event.returnValue = true;
    else {
        event.returnValue = false;

        //alert("Enter NumericValues Only");
    }
}
function ContactNoOnly() {
    var AsciiValue = event.keyCode
    if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127) || AsciiValue == 43 || AsciiValue == 45)
        event.returnValue = true;
    else {
        event.returnValue = false;

        alert("Enter Numerics and + and - Only");
    }
}
function PhoneNumberOnly() {
    var AsciiValue = event.keyCode
    if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127) || (AsciiValue == 45))
        event.returnValue = true;
    else {
        event.returnValue = false;

        //alert("Enter NumericValues Only");
    }
}


function DecimalOnly() {
    var AsciiValue = event.keyCode
    if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127) || AsciiValue == 46)
        event.returnValue = true;
    else {
        event.returnValue = false;

        //alert("Enter DecimalValues Only");
    }
}

function CharOnly() {
    var AsciiValue = event.keyCode
    if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122))
        event.returnValue = true;
    else {
        event.returnValue = false;

        alert("Enter Charcters Only");
    }
}

function CharbarOnly() {
    var AsciiValue = event.keyCode
    if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue == 97 || AsciiValue == 47 || AsciiValue == 45) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127) || (AsciiValue == 32) || (AsciiValue == 44) || (AsciiValue == 46))
        event.returnValue = true;
    else {
        event.returnValue = false;

        alert("Enter Alphanumaric,- and / Only");
    }
}

function CharnumOnly() {
    var AsciiValue = event.keyCode
    if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
        event.returnValue = true;
    else {
        event.returnValue = false;

        alert("Enter Alphanumeric Only");
    }
}

function CharnumOnlyAll() {
    var AsciiValue = event.keyCode
    if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127) || (AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue == 97 || AsciiValue == 47 || AsciiValue == 45) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127) || (AsciiValue == 32) || (AsciiValue == 44) || (AsciiValue == 46) || (AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue == 46) || (AsciiValue == 32))
        event.returnValue = true;
    else {
        event.returnValue = false;

        alert("Enter Alphanumeric,.,-,/ and Space Only");
    }
}

function Names() {
    var AsciiValue = event.keyCode
    if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue == 46) || (AsciiValue == 32))
        event.returnValue = true;
    else {
        event.returnValue = false;

        alert("Enter Alphabets, '.' and Space Only");
    }
}

function Nameandbar() {
    var AsciiValue = event.keyCode
    if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue == 46) || (AsciiValue == 47) || (AsciiValue == 32) || (AsciiValue == 47) || (AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127) || AsciiValue == 43 || AsciiValue == 45)
        event.returnValue = true;
    else {
        event.returnValue = false;

        alert("Enter Alphabets, '.', '/' and Space Only");
    }
}

function Sonof() {
    var AsciiValue = event.keyCode
    if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue == 46) || (AsciiValue == 47) || (AsciiValue == 32))
        event.returnValue = true;
    else {
        event.returnValue = false;

        alert("Enter Alphabets, '.', '/' and Space Only");
    }
}
function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility 
            var charCode = e.which || e.keyCode;
            //            if ((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) {
            //                return true;
            //            }
            if (((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) && charCode != 46 && charCode != 47) {
                return true;
            }
            return false;
        }
//email validation
function echeck(email) {
    var str = document.getElementById(email).value;
    if (str == '') {
        return true
    }
    else {
        var at = "@"
        var dot = "."
        var lat = str.indexOf(at)
        var lstr = str.length
        var ldot = str.indexOf(dot)
        if (str.indexOf(at) == -1) {
            alert("Invalid E-mail ID.Enter like example@xxx.aa")
            return false
        }

        if (str.indexOf(at) == -1 || str.indexOf(at) == 0 || str.indexOf(at) == lstr) {
            alert("Invalid E-mail ID.Enter like example@xxx.aa")
            return false
        }

        if (str.indexOf(dot) == -1 || str.indexOf(dot) == 0 || str.indexOf(dot) == lstr) {
            alert("Invalid E-mail ID.Enter like example@xxx.aa")
            return false
        }

        if (str.indexOf(at, (lat + 1)) != -1) {
            alert("Invalid E-mail ID.Enter like example@xxx.aa")
            return false
        }

        if (str.substring(lat - 1, lat) == dot || str.substring(lat + 1, lat + 2) == dot) {
            alert("Invalid E-mail ID.Enter like example@xxx.aa")
            return false
        }

        if (str.indexOf(dot, (lat + 2)) == -1) {
            alert("Invalid E-mail ID.Enter like example@xxx.aa")
            return false
        }

        if (str.indexOf(" ") != -1) {
            alert("Invalid E-mail ID.Enter like example@xxx.aa")
            return false
        }

        return true
    }


}

function ValidateForm() {
    var emailID = document.frmClientSetup.aspx.txtEmail

    if ((emailID.value == null) || (emailID.value == "")) {
        alert("Please Enter your Email ID")
        emailID.focus()
        return false
    }
    if (echeck(emailID.value) == false) {
        emailID.value = ""
        emailID.focus()
        return false
    }
    return true

}
function ValidateNumberWithoutSpaceAdhar(evt) {
    //var key = window.event.keyCode;
    var key = (evt.which) ? evt.which : event.keyCode;
    var char = String.fromCharCode(key);

    var v = new Array();
    v = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
    var j;
    if (key == 32) {
        return false;
    }
    for (var i = 0; i < v.length; i++) {
        if (char == v[i]) {
            return true;
        }
        else {
            j = j + 1;
        }
    }

    if (j = v.length) {
        return false;
    }
}

function AlphanumericOnlyJs(event) {
    var AsciiValue = (event.which) ? event.which : event.keyCode;
    if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
        return true;
    else {
        return false;
    }
}
function inputOnlyNumbers(evt) {
    var e = window.event || evt; // for trans-browser compatibility 
    var charCode = e.which || e.keyCode;
    //            if ((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) {
    //                return true;
    //            }
    if (((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) && charCode != 46 && charCode != 47) {
        return true;
    }
    return false;
}


function ValidatePAN(evt) {

    var key = (evt.which) ? evt.which : event.keyCode;
    var char = String.fromCharCode(key);

    var Obj = document.getElementById("txtcontact0");
    if (Obj.value != "") {
        ObjVal = Obj.value;
        var panPat = /^([a-zA-Z]{5})(\d{4})([a-zA-Z]{1})$/;
        if (ObjVal.search(panPat) == -1) {
            alert("Invalid Pan No");
            Obj.focus();
            return false;
        }
    }
}
function ValidateNumberWithoutSpaceOnlyrestrictedNumbers(evt, obj) {
    //var key = window.event.keyCode;

    var key = (evt.which) ? evt.which : event.keyCode;
    var char = String.fromCharCode(key);
    var v = new Array();
    v = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
    var j;
    if (key == 32) {
        return false;
    }
    for (var i = 0; i < v.length; i++) {
        if (char == v[i]) {
            return true;
            var tempField = obj.value
            if (tempField > 39) {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            j = j + 1;
        }
    }

    if (j = v.length) {
        return false;
    }

}

function restrictNumberonly(evt, obj) {
    //var key = window.event.keyCode;
    var tempField = obj.value
    if (tempField > 39) {
        obj.value = "";
        return false;
    }
    else {
        return true;
    }
}
//debugger;
function fnValidatePAN(Obj) {
    //debugger;
    if (Obj == null) Obj = window.event.srcElement;
    if (Obj.value != "") {
        ObjVal = Obj.value;
        var panPat = /^([a-zA-Z]{5})(\d{4})([a-zA-Z]{1})$/;
        var code = /([C,P,H,F,A,T,B,L,J,G,c,p,h,f,a,t,b,l,j,g])/;
        var code_chk = ObjVal.substring(3, 4);
        if (ObjVal.search(panPat) == -1) {
            alert("Invalid Pan No");
            Obj.focus();
            Obj.value = "";
            return false;
        }
        if (code.test(code_chk) == false) {
            Obj.value = "";
            alert("Invaild PAN Card No.");
            return false;
        }
    }
}

function fnValidateGSTIN(Obj) {
    //debugger;
    if (Obj == null) Obj = window.event.srcElement;
    if (Obj.value != "") {
        ObjVal = Obj.value;
        var panPat = /^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$/;
        if (ObjVal.search(panPat) == -1) {
            alert("Invalid GST No");
            Obj.focus();
            Obj.value = "";
            return false;
        }
    }
}

function Adharcontrol(evt, obj, dd, mm, yyyy) {

    //debugger                        
    //var fieldkey = window.event.keyCode;
    var fieldkey = (evt.which) ? evt.which : event.keyCode;
    var tempField = obj.value.split('');
    var flag = false;
    var bck = false;
    //var fieldkey = window.event.keyCode;
    var fieldkey = (evt.which) ? evt.which : event.keyCode;
    switch (fieldkey) {
        case 48:
        case 49:
        case 50:
        case 51:
        case 52:
        case 53:
        case 54:
        case 55:
        case 56:
        case 57:
        case 96:
        case 97:
        case 98:
        case 99:
        case 100:
        case 101:
        case 102:
        case 103:
        case 104:
        case 105:
            flag = true;
            break;
        case 8:
            bck = true;
            break;
    }

    if (parseInt(tempField.length, 10) >= 4 && flag == true) {
        if (obj.id == document.getElementById(dd).id) {
            document.getElementById(mm).focus();
        }
    }
    if (parseInt(tempField.length, 10) >= 4 && flag == true) {
        if (obj.id == document.getElementById(mm).id) {
            document.getElementById(yyyy).focus();
        }
    }
    return false;
}

function ValidateDecimal(field, ff) {
    fieldvalue = ff.value;
    // alert(fieldvalue);
    // var fieldkey = window.event.keyCode;
    var fieldkey = (field.charCode) ? field.which : event.keyCode
    var fieldchar = String.fromCharCode(fieldkey);
    if (fieldkey == 32) {
        return false;
    }
    if (fieldkey == 46) {
        var dot = fieldvalue.concat(fieldchar);
        fieldvalue = new String(dot);
        dotfirstpos = dot.indexOf(".");
        dot2ndpos = dot.lastIndexOf(".");
        if (dotfirstpos == dot2ndpos) {
            return true;
        }
        else {

            return false;
        }
    }
    var ArrNumeric = new Array();
    ArrNumeric = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
    var Numpos;
    for (var intNumPos = 0; intNumPos < ArrNumeric.length; intNumPos++) {
        if (fieldchar == ArrNumeric[intNumPos]) {
            return true;
        }
        else {
            Numpos = Numpos + 1;
        }
    }

    if (Numpos = ArrNumeric.length) {

        return false;
    }

}

