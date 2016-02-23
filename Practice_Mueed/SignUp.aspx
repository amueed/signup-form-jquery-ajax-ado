<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="http://code.jquery.com/ui/1.11.4/jquery-ui.js"></script>

    <script src="http://ajax.aspnetcdn.com/ajax/jquery.validate/1.13.1/jquery.validate.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.validate/1.13.1/jquery.validate.min.js"></script>


    <script src="signup.js" type="text/javascript"></script>
    <link href="style.css" rel="stylesheet" />




</head>
<body>
    <form id="SignUpForm" runat="server">
    <div>
            <table align="center">
                <tr><th colspan="2">Sign Up Form</th></tr>
            <tr><td>First Name</td><td><input type="text" id="txtFname" name="txtFname" class="normal"/></td></tr>
            <tr><td>Last Name</td><td>
                <input type="text" id="txtLname" name="txtLname"/></td></tr>
            <tr><td>Gender</td><td><input type="radio" name="rbGender" value="male" checked/>Male
                                    <input type="radio" name="rbGender" value="female"/>Female</td></tr>
            <tr><td>Address</td><td><input type="text" id="txtAddress" name="txtAddress"/></td></tr>
            <tr><td>Email</td><td><input type="text" id="txtEmail" name="txtEmail"/></td></tr>
            <tr><td>Username</td><td><input type="text" id="txtUsername" name="txtUsername" onblur="checkUser();"/></td></tr>
            <tr><td>Password</td><td><input type="password" id="txtPassword" name="txtPassword"/></td></tr>
            <tr><td>Confirm Password</td><td><input type="password" id="txtCPassword" name="txtCPassword"/></td></tr>
            <tr><td></td><td><input type="submit"  id="btnSubmit" value="Submit" onclick="return Insert();"/></td></tr>

        </table>
        <div id="errorBox"></div>
        <br />
            <asp:GridView ID="gvUsers" runat="server" align="center" Width="75%"></asp:GridView>

    </div>
    </form>

</body>
</html>
