
jQuery(document).ready(function () {

    /*
        Login form validation
    */
    $('.login-form input[type="text"], .login-form input[type="password"], .login-form textarea').on('focus', function () {
        $(this).removeClass('input-error');
    });

    $('.login-form').on('submit', function (e) {

        $(this).find('input[type="text"], input[type="password"], textarea').each(function () {
            if ($(this).val() == "") {
                e.preventDefault();
                $(this).addClass('input-error');
            }
            else {
                $(this).removeClass('input-error');
            }
        });

    });

    /*
        Registration form validation
    */
    $('.registration-form input[type="text"], .registration-form textarea').on('focus', function () {
        $(this).removeClass('input-error');
    });

    $('.registration-form').on('submit', function (e) {

        $(this).find('input[type="text"], textarea').each(function () {
            if ($(this).val() == "") {
                e.preventDefault();
                $(this).addClass('input-error');
            }
            else {
                $(this).removeClass('input-error');
            }
        });
        $(this).find('input[type="password"], textarea').each(function () {
            if ($(this).val() == "") {
                e.preventDefault();
                $(this).addClass('input-error');
            }
            else {
                $(this).removeClass('input-error');
            }
        });
        $(this).find('input[type="email"], textarea').each(function () {
            if ($(this).val() == "") {
                e.preventDefault();
                $(this).addClass('input-error');
            }
            else {
                $(this).removeClass('input-error');
            }
        });

    });
    $('#reg-form-email').on("blur",
      function (value, element) {
          var result = false;
          console.log('in validation');
          var value = $('#reg-form-email').val();
          $.ajax({
              type: "POST",
              async: false,
              url: "/Class/validateEmail", // script to validate in server side
              data: "email=" + value,
              success: function (data) {
                  if (data == "true") {
                      $('#reg-form-email').removeClass('input-error');
                  }
                  else {
                      $('#reg-form-email').addClass('input-error');

                  }
              }

          });


      });
    
});
