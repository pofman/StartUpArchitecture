var source = '<form data-bind="submit: save">'
    + '{{#if isUpdate}} <input type="hidden" data-bind="value:Id" /> {{/if}}'
    + '<div> <label for="firstName">First name:</label> <input id="firstName" type="text" data-bind="value:FirstName" /></div>'
    + '<div><label for="lastName">Last name:</label><input id="lastName" type="text" data-bind="value:LastName" /></div>'
    + '<div><label for="userName">Username:</label><input id="userName" type="text" data-bind="value:UserName" /></div>'
    + '{{#unless isUpdate}} <div><label for="password">Password:</label><input id="password" type="password" data-bind="value:Password" /></div> {{/unless}}'
    + '<div><button type="submit">Save</button></div></form>';

var users_form_template = Handlebars.compile(source);

