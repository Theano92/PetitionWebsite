/*validate sign in form*/
function validateForm() {
    var x = document.forms["form"]["email"].value;
    var y = document.forms["form"]["password"].value;
    

    if (x==null || x == "") {
        alert("Email must be filled out");
        return false;
    }
    if (y==null || y == "") {
        alert("Password must be filled out");
        return false;
    }
   
} 
/*validate sign up form*/
function signupForm() {
    var x = document.forms["signform"]["fname"].value;
    var y = document.forms["signform"]["lname"].value;
    var k = document.forms["signform"]["email"].value;
    var l = document.forms["signform"]["password"].value;


    if (x == null || x == "") {
        alert("Name must be filled out");
        return false;
    }
    else if (y == null || y == "") {
        alert("Last name must be filled out");
        return false;
    }
    else if (k == null || k == "") {
        alert("Email must be filled out");
        return false;
    }
    else {
        alert("password must be filled out");
        return false;
    }

} 
/*hide and show petition and search bar*/
$("#load_more").hide();
$("#hide").hide();
$("#search").hide();

  $(document).ready(function () {
        $("#show").click(function () {
            $("#load_more").show("2000");
            $("#show").hide();
            $("#hide").show();
      });
        $("#hide").click(function () {
            $("#load_more").hide("2000");
            $("#show").show();
            $("#hide").hide();
        });
        
        $("#search_show").click(function () {
            $("#search").toggle();
            return false; 
        })

});

  

