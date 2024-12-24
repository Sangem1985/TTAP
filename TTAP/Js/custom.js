

function sum() {
    var txtFirstNumberValue = document.getElementById('ContentPlaceHolder1_txtLaborSkilled').value;
    var txtSecondNumberValue = document.getElementById('ContentPlaceHolder1_txtLaborUnSkilled').value;
    var txtThirdNumberValue = document.getElementById('ContentPlaceHolder1_txtSupervisory').value;
    
    if (txtFirstNumberValue == "")
        txtFirstNumberValue = 0;
    if (txtSecondNumberValue == "")
        txtSecondNumberValue = 0;
    if (txtThirdNumberValue == "")
        txtThirdNumberValue = 0;


    var result = parseInt(txtFirstNumberValue) + parseInt(txtSecondNumberValue) + parseInt(txtThirdNumberValue);
    if (!isNaN(result)) {
        document.getElementById('ContentPlaceHolder1_txtlaborTotal').value = result;
    }
}