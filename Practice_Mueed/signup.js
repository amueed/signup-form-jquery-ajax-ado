$(document).ready(function () {
});

function Insert() {
    var fname = $("#txtFname").val();
    var lname = $("#txtLname").val();
    var address = $("#txtAddress").val();
    var email = $("#txtEmail").val();
    var username = $("#txtUsername").val();
    var password = $("#txtPassword").val();
    var cpassword = $("#txtCPassword").val();
    var gender = $('input[name=rbGender]:checked').val();
    var alphabetRegex = /^[(a-z)(A-Z)]+$/;
    var alphaNumericRegex = /^[(a-z)(A-Z)(0-9)]+$/;
    var numericRegex = /^[(0-9)]+$/;
    var emailRegex = /^[A-Za-z0-9._]*\@[A-Za-z]*\.[A-Za-z]{2,5}$/;

    if (fname.length == 0) {
        alert("Enter First Name");
        $("#txtFname").focus();
        return false;
    }
    if (address.length == 0) {
        alert("Enter Address");
        return false;
    }
    if (email.length == 0) {
        alert("Enter Email");
        return false;
    }
    if (username.length == 0) {
        alert("Enter Username");
        return false;
    }
    if (password.length == 0) {
        alert("Enter Password");
        return false;
    }
    if (cpassword.length == 0) {
        alert("Enter Confirm Password");
        return false;
    }
    if (!(fname.match(alphabetRegex))) {
        alert("First Name field accept alphabets only.");
        return false;
    }
    if (!(lname.match(alphabetRegex))) {
        alert("Last Name field accept alphabets only.");
        $("#txtLname").focus();
        return false;
    }
    if (!(email.match(emailRegex))) {
        alert("Invalid Format of Email. Example: user@company.com");
        return false;
    }
    if (!(username.match(alphaNumericRegex))) {
        alert("username can not contain special charaters.");
        return false;
    }
    if (password != cpassword) {
        alert("Password & Confirm Password must be same.");
        return false;
    }

    $.ajax({
        type: "POST",
        url: "SignUp.aspx/InsertData",
        data: '{Fname:"' + fname + '", Lname:"' + lname + '", Gender:"' + gender + '", Address:"' + address + '", Email:"' + email + '", Username:"' + username + '", Password:"' + password + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.d);
        },

        failure: function () {
            alert("Fail");
        }
    });
    return true;
}

function checkUser() {
    var username = $("#txtUsername").val();
    var result;
    $.ajax({
        type: "POST",
        url: "SignUp.aspx/CheckUsername",
        data: '{Username:"' + username + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (respond) {
            if (respond.d == "1") {
                alert(username + " alredy exists.");
                $("#btnSubmit").hide();
                result = false;
            }
            else {
                result = true;
                $("#btnSubmit").show();
            }
        },

        failure: function (response) {
            return (response.d);
        }
    });
}