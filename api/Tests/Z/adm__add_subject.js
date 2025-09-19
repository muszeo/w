var _idp = z.globals.get("idp");
var _api = z.globals.get("api");
var _creds = "client_id=P3ZHO6RABMSFGXPFMXTG8CKWJ5QDEMEXRXIBSFJRLCLYHSPW&client_secret=Z5X6OVFCFBS4KENGJT9Q1YJYQY15VHYZJ1GGZSL8YF1WCLIJ&scope=profile%20openid%20email%20metricApi.read%20metricApi.write&username=" + z.globals.get("user") + "&password=" + z.globals.get("pwd") + "&grant_type=password";
z.debug();

// Get Attributes
var _name = z.globals.get("name");
var _description = z.globals.get("description");

if (_name != null) {

    z.crlf();
    z.out(">>> Metric Service - Metric Subject Tests <<<");

    // Get Access Token
    var _r = z.post(_idp, "connect/token", _creds, "application/x-www-form-urlencoded");
    z.assert.ok(_r, "Connect/Token Response OK");
    z.vars.set("token", "Bearer " + _r.json.access_token);

    // POST new Metric Observation Subject
    z.crlf();
    z.out("POST Metric Observation Subject");
    var _body = `{ "Name": "${_name}", "Description": "${_description}" }`;
    _r = z.post(_api, "subject", _body, "application/json", null, z.vars.get("token"));
    var _subjectId = _r.json.id;
    z.crlf();
    z.assert.ok(_r);
    z.assert.true(_subjectId != 0, "Subject ID is not 0");

    // GET created Metric Observation Subject
    z.crlf();
    z.out("GET Metric Observation Subject");
    var _r = z.get(_api, `subject/${_subjectId}`, z.vars.get("token"));
    z.out("Retrieved following Metric Observation Subject data:");
    z.crlf();
    z.out(_r.body);
    z.crlf();
    z.assert.ok(_r);

}