var _idp = z.globals.get("idp");
var _api = z.globals.get("api");

var _creds = "client_id=P3ZHO6RABMSFGXPFMXTG8CKWJ5QDEMEXRXIBSFJRLCLYHSPW&client_secret=Z5X6OVFCFBS4KENGJT9Q1YJYQY15VHYZJ1GGZSL8YF1WCLIJ&scope=profile%20openid%20email%20metricApi.read%20metricApi.write&username=" + z.globals.get("user") + "&password=" + z.globals.get("pwd") + "&grant_type=password";
z.debug();

// Get Access Token
var _r = z.post(_idp, "connect/token", _creds, "application/x-www-form-urlencoded");
z.assert.ok(_r, "Connect/Token Response OK");
z.vars.set("token", "Bearer " + _r.json.access_token);
z.crlf();
z.out(">>> Access Token <<<");
z.out(_r.json.access_token);


z.crlf();
z.out(">>> Metric Service Tests <<<");

// ****** METRIC ******

// POST new Metric Topic
z.crlf();
z.out("POST Metric Topic");
var _body = `{ "Name": "Test_Metric_Topic_A", "Description": "Test_Metric_Topic_A_Description" }`;
_r = z.post(_api, "topic", _body, "application/json", null, z.vars.get("token"));
var _topicId = _r.json.id;
z.crlf();
z.assert.ok(_r);
z.assert.true(_topicId != 0, "Topic ID is not 0");

// GET created Metric Topic
z.crlf();
z.out("GET Metric Topic");
var _r = z.get(_api, `topic/${_topicId}`, z.vars.get("token"));
z.out("Retrieved following Metric Topic data:");
z.crlf();
z.out(_r.body);
z.crlf();
z.assert.ok(_r);


// POST new Metric Group
z.crlf();
z.out("POST Metric Group");
var _body = `{ "Name": "Test_Metric_Group_A", "Description": "Test_Metric_Group_A_Description" }`;
_r = z.post(_api, "group", _body, "application/json", null, z.vars.get("token"));
var _groupId = _r.json.id;
z.crlf();
z.assert.ok(_r);
z.assert.true(_groupId != 0, "Group ID is not 0");

// GET created Metric Group
z.crlf();
z.out("GET Metric Group");
var _r = z.get(_api, `group/${_groupId}`, z.vars.get("token"));
z.out("Retrieved following Metric Group data:");
z.crlf();
z.out(_r.body);
z.crlf();
z.assert.ok(_r);


// ****** METRIC TYPES ******

// POST new 'nI' (Integer) Metric
z.crlf();
z.out("POST Integer Metric");
var _body = `{ "TopicId": "${_topicId}", "GroupId": "${_groupId}", "Type": "0", "Name": "Test_Metric_nI_A", "Description": "Integer_Test_Metric_A_Description" }`;
_r = z.post(_api, "metric", _body, "application/json", null, z.vars.get("token"));
var _nI_metricId = _r.json.id;
z.crlf();
z.assert.ok(_r);
z.assert.true(_nI_metricId != 0, "Integer Metric ID is not 0");

// GET created 'nI' (Integer) Metric
z.crlf();
z.out("GET Integer Metric");
var _r = z.get(_api, `metric/${_nI_metricId}`, z.vars.get("token"));
z.out("Retrieved following Integer Metric data:");
z.crlf();
z.out(_r.body);
z.crlf();
z.assert.ok(_r);


// POST new 'nD' (Decimal) Metric
z.crlf();
z.out("POST Decimal Metric");
var _body = `{ "TopicId": "${_topicId}", "GroupId": "${_groupId}", "Type": "1", "Name": "Test_Metric_nD_A", "Description": "Decimal_Test_Metric_A_Description" }`;
_r = z.post(_api, "metric", _body, "application/json", null, z.vars.get("token"));
var _nD_metricId = _r.json.id;
z.crlf();
z.assert.ok(_r);
z.assert.true(_nD_metricId != 0, "Decimal Metric ID is not 0");

// GET created 'nD' (Decimal) Metric
z.crlf();
z.out("GET Decimal Metric");
var _r = z.get(_api, `metric/${_nD_metricId}`, z.vars.get("token"));
z.out("Retrieved following Decimal  Metric data:");
z.crlf();
z.out(_r.body);
z.crlf();
z.assert.ok(_r);


// POST new 'dT' (DateTime) Metric
z.crlf();
z.out("POST DateTime Metric");
var _body = `{ "TopicId": "${_topicId}", "GroupId": "${_groupId}", "Type": "2", "Name": "Test_Metric_dT_A", "Description": "DateTime_Test_Metric_A_Description" }`;
_r = z.post(_api, "metric", _body, "application/json", null, z.vars.get("token"));
var _dT_metricId = _r.json.id;
z.crlf();
z.assert.ok(_r);
z.assert.true(_dT_metricId != 0, "DateTime Metric ID is not 0");

// GET created 'dT' (DateTime) Metric
z.crlf();
z.out("GET DateTime Metric");
var _r = z.get(_api, `metric/${_dT_metricId}`, z.vars.get("token"));
z.out("Retrieved following DateTime  Metric data:");
z.crlf();
z.out(_r.body);
z.crlf();
z.assert.ok(_r);


// POST new 'tX' (Text) Metric
z.crlf();
z.out("POST Text Metric");
var _body = `{ "TopicId": "${_topicId}", "GroupId": "${_groupId}", "Type": "3", "Name": "Test_Metric_tX_A", "Description": "Text_Test_Metric_A_Description" }`;
_r = z.post(_api, "metric", _body, "application/json", null, z.vars.get("token"));
var _tX_metricId = _r.json.id;
z.crlf();
z.assert.ok(_r);
z.assert.true(_tX_metricId != 0, "Text Metric ID is not 0");

// GET created 'tX' (Text) Metric
z.crlf();
z.out("GET Text Metric");
var _r = z.get(_api, `metric/${_tX_metricId}`, z.vars.get("token"));
z.out("Retrieved following Text Metric data:");
z.crlf();
z.out(_r.body);
z.crlf();
z.assert.ok(_r);


// POST new 'tC' (Code) Metric
z.crlf();
z.out("POST Text Code Metric");
var _body = `{ "TopicId": "${_topicId}", "GroupId": "${_groupId}", "Type": "4", "Name": "Test_Metric_tC_A", "Description": "Text_Code_Test_Metric_A_Description" }`;
_r = z.post(_api, "metric", _body, "application/json", null, z.vars.get("token"));
var _tC_metricId = _r.json.id;
z.crlf();
z.assert.ok(_r);
z.assert.true(_tC_metricId != 0, "Text Code Metric ID is not 0");

// GET created 'tC' (Code) Metric
z.crlf();
z.out("GET Text Code Metric");
var _r = z.get(_api, `metric/${_tC_metricId}`, z.vars.get("token"));
z.out("Retrieved following Text Code Metric data:");
z.crlf();
z.out(_r.body);
z.crlf();
z.assert.ok(_r);




// ****** OBSERVATION ******

// POST new Metric Observation Subject
z.crlf();
z.out("POST Metric Observation Subject");
var _body = `{ "Name": "Test_Subject_A", "Description": "Test_Subject_A_Description" }`;
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


// POST new Metric Observation Source
z.crlf();
z.out("POST Metric Observation Source");
var _body = `{ "Name": "Test_Source_A", "Description": "Test_Source_A_Description", "Type": "ApiTestClient", "Code": "ZAPIT_TXC" }`;
_r = z.post(_api, "source", _body, "application/json", null, z.vars.get("token"));
var _sourceId = _r.json.id;
z.crlf();
z.assert.ok(_r);
z.assert.true(_sourceId != 0, "Source ID is not 0");

// GET created Metric Observation Source
z.crlf();
z.out("GET Metric Observation Source");
var _r = z.get(_api, `source/${_sourceId}`, z.vars.get("token"));
z.out("Retrieved following Metric Observation Source data:");
z.crlf();
z.out(_r.body);
z.crlf();
z.assert.ok(_r);


// POST new Metric Observation Identity Context
z.crlf();
z.out("POST Metric Observation Identity Context");
var _body = `{ "Start": "2025-06-05T05:00:00", "End": "2025-06-05T05:30:00" }`;
_r = z.post(_api, "context", _body, "application/json", null, z.vars.get("token"));
var _contextId = _r.json.id;
z.crlf();
z.assert.ok(_r);
z.assert.true(_contextId != 0, "Identity Context ID is not 0");

// GET created Metric Observation Identity Context
z.crlf();
z.out("GET Metric Observation Identity Context");
var _r = z.get(_api, `context/${_contextId}`, z.vars.get("token"));
z.out("Retrieved following Metric Observation Identity Context data:");
z.crlf();
z.out(_r.body);
z.crlf();
z.assert.ok(_r);




// ****** OBSERVATION ******

// POST new nI Metric Observation
z.crlf();
z.out("POST Integer Metric Observation");
var _body = `{ "SourceId": "${_sourceId}", "ContextId": "${_contextId}", "SubjectId": "${_subjectId}", "Timestamp": "2025-06-04T05:30:00", "nI": "73" }`;
_r = z.post(_api, `metric/${_nI_metricId}/observation`, _body, "application/json", null, z.vars.get("token"));
var _observationId = _r.json.id;
z.crlf();
z.assert.ok(_r);
z.assert.true(_observationId != 0, "Integer Metric Observation ID is not 0");

// POST new nI Metric Observations (BULK A)
z.crlf();
z.out("POST Integer Metric Observations -- BULK A");
var _body = `[{ "SourceId": "${_sourceId}", "ContextId": "${_contextId}", "SubjectId": "${_subjectId}", "Timestamp": "2025-06-04T05:30:00", "nI": "74" }]`;
_r = z.post(_api, `metric/${_nI_metricId}/observations`, _body, "application/json", null, z.vars.get("token"));
var _length = _r.json.items.length;
z.crlf();
z.assert.ok(_r);
z.assert.true(_length == 1, "Integer Metric Observations created");


// POST new nD Metric Observation
z.crlf();
z.out("POST Decimal Metric Observation");
var _body = `{ "SourceId": "${_sourceId}", "ContextId": "${_contextId}", "SubjectId": "${_subjectId}", "Timestamp": "2025-06-04T05:30:00", "nD": "73.37" }`;
_r = z.post(_api, `metric/${_nD_metricId}/observation`, _body, "application/json", null, z.vars.get("token"));
var _observationId = _r.json.id;
z.crlf();
z.assert.ok(_r);
z.assert.true(_observationId != 0, "Decimal Metric Observation ID is not 0");

// POST new nD Metric Observations (BULK A)
z.crlf();
z.out("POST Decimal Metric Observations -- BULK A");
var _body = `[{ "SourceId": "${_sourceId}", "ContextId": "${_contextId}", "SubjectId": "${_subjectId}", "Timestamp": "2025-06-04T05:30:00", "nD": "74.47" }]`;
_r = z.post(_api, `metric/${_nD_metricId}/observations`, _body, "application/json", null, z.vars.get("token"));
var _length = _r.json.items.length;
z.crlf();
z.assert.ok(_r);
z.assert.true(_length == 1, "Decimal Metric Observations created");


// POST new dT Metric Observation
z.crlf();
z.out("POST DateTime Metric Observation");
var _body = `{ "SourceId": "${_sourceId}", "ContextId": "${_contextId}", "SubjectId": "${_subjectId}", "Timestamp": "2025-06-04T05:30:00", "dT": "2025-06-04T05:30:00" }`;
_r = z.post(_api, `metric/${_dT_metricId}/observation`, _body, "application/json", null, z.vars.get("token"));
var _observationId = _r.json.id;
z.crlf();
z.assert.ok(_r);
z.assert.true(_observationId != 0, "DateTime Metric Observation ID is not 0");

// POST new dT Metric Observations (BULK A)
z.crlf();
z.out("POST DateTime Metric Observations -- BULK A");
var _body = `[{ "SourceId": "${_sourceId}", "ContextId": "${_contextId}", "SubjectId": "${_subjectId}", "Timestamp": "2025-06-04T05:30:00", "dT": "2025-06-04T05:30:00" }]`;
_r = z.post(_api, `metric/${_dT_metricId}/observations`, _body, "application/json", null, z.vars.get("token"));
var _length = _r.json.items.length;
z.crlf();
z.assert.ok(_r);
z.assert.true(_length == 1, "DateTime Metric Observations created");


// POST new tX Metric Observation
z.crlf();
z.out("POST Text Metric Observation");
var _body = `{ "SourceId": "${_sourceId}", "ContextId": "${_contextId}", "SubjectId": "${_subjectId}", "Timestamp": "2025-06-04T05:30:00", "tX": "SOMELONGTEXT" }`;
_r = z.post(_api, `metric/${_tX_metricId}/observation`, _body, "application/json", null, z.vars.get("token"));
var _observationId = _r.json.id;
z.crlf();
z.assert.ok(_r);
z.assert.true(_observationId != 0, "Text Metric Observation ID is not 0");

// POST new tX Metric Observations (BULK A)
z.crlf();
z.out("POST Text Metric Observations -- BULK A");
var _body = `[{ "SourceId": "${_sourceId}", "ContextId": "${_contextId}", "SubjectId": "${_subjectId}", "Timestamp": "2025-06-04T05:30:00", "tX": "SOMELONGTEXT" }]`;
_r = z.post(_api, `metric/${_tX_metricId}/observations`, _body, "application/json", null, z.vars.get("token"));
var _length = _r.json.items.length;
z.crlf();
z.assert.ok(_r);
z.assert.true(_length == 1, "Text Metric Observations created");


// POST new tC Metric Observation
z.crlf();
z.out("POST Text Code Metric Observation");
var _body = `{ "SourceId": "${_sourceId}", "ContextId": "${_contextId}", "SubjectId": "${_subjectId}", "Timestamp": "2025-06-04T05:30:00", "tC": "CODE" }`;
_r = z.post(_api, `metric/${_tC_metricId}/observation`, _body, "application/json", null, z.vars.get("token"));
var _observationId = _r.json.id;
z.crlf();
z.assert.ok(_r);
z.assert.true(_observationId != 0, "Text Code Metric Observation ID is not 0");

// POST new tC Metric Observations (BULK A)
z.crlf();
z.out("POST Text Code Metric Observations -- BULK A");
var _body = `[{ "SourceId": "${_sourceId}", "ContextId": "${_contextId}", "SubjectId": "${_subjectId}", "Timestamp": "2025-06-04T05:30:00", "tC": "CODE" }]`;
_r = z.post(_api, `metric/${_tC_metricId}/observations`, _body, "application/json", null, z.vars.get("token"));
var _length = _r.json.items.length;
z.crlf();
z.assert.ok(_r);
z.assert.true(_length == 1, "Text Code Metric Observations created");


// POST new Metric Observations (BULK B)
z.crlf();
z.out("POST Metric Observations -- BULK B");
var _body = `[`
    + `{ "MetricId": "${_nI_metricId}", "SourceId": "${_sourceId}", "ContextId": "${_contextId}", "SubjectId": "${_subjectId}", "Timestamp": "2025-06-04T05:30:00", "nI": "74" }, `
    + `{ "MetricId": "${_nD_metricId}", "SourceId": "${_sourceId}", "ContextId": "${_contextId}", "SubjectId": "${_subjectId}", "Timestamp": "2025-06-04T05:30:00", "nD": "73.37" }, `
    + `{ "MetricId": "${_dT_metricId}", "SourceId": "${_sourceId}", "ContextId": "${_contextId}", "SubjectId": "${_subjectId}", "Timestamp": "2025-06-04T05:30:00", "dT": "2025-06-04T05:30:00" }, `
    + `{ "MetricId": "${_tX_metricId}", "SourceId": "${_sourceId}", "ContextId": "${_contextId}", "SubjectId": "${_subjectId}", "Timestamp": "2025-06-04T05:30:00", "tX": "SOMELONGTEXT" }, `
    + `{ "MetricId": "${_tC_metricId}", "SourceId": "${_sourceId}", "ContextId": "${_contextId}", "SubjectId": "${_subjectId}", "Timestamp": "2025-06-04T05:30:00", "tC": "CODE" }`
    + `]`;
_r = z.post(_api, `metric/observations`, _body, "application/json", null, z.vars.get("token"));
var _length = _r.json.items.length;
z.crlf();
z.assert.ok(_r);
z.assert.true(_length == 1, "Metric Observations BULK B created");
