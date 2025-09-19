var _idp = z.globals.get("idp");
var _api = z.globals.get("api");

var _creds = "client_id=P3ZHO6RABMSFGXPFMXTG8CKWJ5QDEMEXRXIBSFJRLCLYHSPW&client_secret=Z5X6OVFCFBS4KENGJT9Q1YJYQY15VHYZJ1GGZSL8YF1WCLIJ&scope=profile%20openid%20email%20metricApi.read%20metricApi.write&username=" + z.globals.get("user") + "&password=" + z.globals.get("pwd") + "&grant_type=password";
z.debug();

// Header
z.out(">>>                                                                                                                <<<");
z.out(">                                                                                                                    <");
z.out(">                                    Metric Service PRODUCTION VERIFICATION Tests                                    <");
z.out(">                                                                                                                    <");
z.out(">   These tests are intended to provide a smoke-test verification of a Production release of Metrics Solution only   <");
z.out(">                                                                                                                    <");
z.out(">>>                                                                                                                <<<");
z.crlf();

// Get Access Token
var _r = z.post(_idp, "connect/token", _creds, "application/x-www-form-urlencoded");
z.assert.ok(_r, "Connect/Token Response OK");
z.vars.set("token", "Bearer " + _r.json.access_token);
z.crlf();
z.out(">>> Access Token <<<");
z.out(_r.json.access_token);


z.crlf();
z.out(">>> Metric Service Tests <<<");

// GET Metric Topic 1
z.crlf();
z.out("GET Metric Topic #1");
var _r = z.get(_api, `topic/1`, z.vars.get("token"));
z.out("Retrieved following Metric Topic data:");
z.crlf();
z.out(_r.body);
z.crlf();
z.assert.ok(_r);

// GET Metric Group 1
z.crlf();
z.out("GET Metric Group #1");
var _r = z.get(_api, `group/1`, z.vars.get("token"));
z.out("Retrieved following Metric Group data:");
z.crlf();
z.out(_r.body);
z.crlf();
z.assert.ok(_r);

// GET Metric 1
z.crlf();
z.out("GET Metric #1");
var _r = z.get(_api, `metric/1`, z.vars.get("token"));
z.out("Retrieved following Metric data:");
z.crlf();
z.out(_r.body);
z.crlf();
z.assert.ok(_r);

// GET Metric Observation Subject 1
z.crlf();
z.out("GET Metric Observation Subject #1");
var _r = z.get(_api, `subject/1`, z.vars.get("token"));
z.out("Retrieved following Metric Observation Subject data:");
z.crlf();
z.out(_r.body);
z.crlf();
z.assert.ok(_r);

// GET Metric Observation Source 1
z.crlf();
z.out("GET Metric Observation Source #1");
var _r = z.get(_api, `source/1`, z.vars.get("token"));
z.out("Retrieved following Metric Observation Source data:");
z.crlf();
z.out(_r.body);
z.crlf();
z.assert.ok(_r);
