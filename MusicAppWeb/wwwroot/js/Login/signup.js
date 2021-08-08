$(document).ready(function() {
    $("#btnSubmit").click(function() {
        const valid = validate();

        if (valid)
            $("#formSignUp").submit();
    });

});

function validate() {
    const username = $("[name='username']").val();
    if (username == "")
    {
        alert("Enter a username");

        return false;
    }

    const email = $("[name='email'").val();
    if (email == "")
    {
        alert("Enter email.")

        return false; 
    }

    const pass = $("[name='password']").val();
    const confirmPass = $("[name='confirm_password']").val();

    if (pass == "" || pass != confirmPass) {
        
        if (pass == "")
            alert("Enter a password");
        else  
            alert("Passwords don't match");

        return false;
    }
    
    return true;
}