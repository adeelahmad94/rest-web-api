// JavaScript Document

$('document').ready(function () {

    $('#form-email').on("blur",
       function (value, element) {
           var result = false;
           console.log('in validation');
           var value = $('#form-email').val();
           $.ajax({
               type: "POST",
               async: false,
               url: "/Class/validateEmail", // script to validate in server side
               data:  "email=" + value,
               success: function (data) {
                   if (data == "true") {
                       
                   }
               }

           });


           $.validator.addMethod("checkEmail",
              function (value, element) {
                  var result = false;
                  console.log('in validation');
                  $.ajax({
                      type: "POST",
                      async: false,
                      url: "/Class/validateEmail", // script to validate in server side
                      data: { email: value },
                      success: function (data) {
                          result = (data == "true") ? true : false;
                      }

                  });

                  console.log(result);
                  return result;
              },
              "This Email is already Registered."
          );

           /* validation */
           $('#reg-form').validate({
               onfocusout: false,
               rules: {
                   email: {
                       required: true,
                       email: true,
                       checkEmail: true
                   }
            
            
               },
               messages:
               {    
           
                   email: {
                       email: "Enter a valid Email",
                       checkEmail: "This email is already Registered"
                   }
               },

               /* form submit */




           });
       });
})