ko.validation.locale('ru-RU');
ko.validation.init({

    registerExtenders: true,
    messagesOnModified: true,
    insertMessages: true,
    parseInputAttributes: true,
    errorClass: 'text-danger',
    messageTemplate: null

}, true);

var userModel = {
    Username: ko.observable().extend({
        required: true,
        minLength: 5
    }),
    Email: ko.observable().extend({
        required: true,
        email: true
    }),
    Password: ko.observable().extend({
        required: true,
        minLength: 6
    }),
    ConfirmPassword: ko.observable().extend({ equal: Password }),

    registerBtn: function () {
        var data = {
            Username: this.Username(),
            Email: this.Email(),
            Password: this.Password(),
            ConfirmPassword: this.ConfirmPassword()
        };

        postData(data);
    },

    cancelBtn: function () {
        location.pathname = "/Home/Index/";
    }
}
ko.applyBindings(userModel);

var postData = function (data) {
    $.post("/Users/Create", data, function (result) {
        if (result.IsSuccess) {
            alert("Ваша учетная запись успешно создана!");
            location.pathname = "/Home/Index/";
        }
        else {
            $('#Username').before("<div class=\"alert alert-danger alert-dismissible\">" +
                "<a class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>" +
                result.ErrorMsg
                + "</div>")
        }
    })
}