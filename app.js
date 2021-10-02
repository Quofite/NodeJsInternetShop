//--------------------- getting backend packages ---
const express = require("express"); // + express
const app = express();              // creating app(server) object

const jsonParser = express.json();  // + json parser

const mysql = require("mysql2");    // + mysql
const dbdata = require("./dbdata"); // + db data

//--------------------- getting frontend packages --

app.use(express.static(__dirname + "/views"));          // setting static files directory

//-------------- custom functions --------------------------
// still nothing here but maybe would

//-------------- get-requests ------------------------------
app.get("/", function (request, response) {
    response.sendFile(__dirname + "/views/index.html");
});

app.get("/ferrari488", function (request, response) {
    response.sendFile(__dirname + "/views/ferrari488.html");
});

app.get("/vaz2101", function (request, response) {
    response.sendFile(__dirname + "/views/vaz2101.html");
});

app.get("/dallaradw12", function (request, response) {
    response.sendFile(__dirname + "/views/dallaradw12.html");
});

app.get("/newreview", function (request, response) {
    response.sendFile(__dirname + "/views/review.html");
});

app.get("/buy", function (request, response) {
    response.sendFile(__dirname + "/views/buy.html");
});

app.get("/success", function (request, response) {
    response.sendFile(__dirname + "/views/success.html");
});

app.get("/questions", function (request, response) {
    response.sendFile(__dirname + "/views/questions.html");
});

app.get("/getReviews", function(request, response){
    // getting mysql connection
    const connection = mysql.createConnection({
        host: dbdata.host,
        user: dbdata.user,
        password: dbdata.pass,
        database: dbdata.db
    });

    const sql = `SELECT * FROM reviews`;    // sql string
    var result = "";  // variable that will contain all reviews

    connection.query(sql, function(err, results){
        if(err) throw err;  // if there are an error it will be thrown (maybe better just to show it in console but not to crash server bruh)

        var inter = results;    // variable with results of sql query

        // loop that will make reviews blocks to send them to the client
        for(var i = 0; i < inter.length; i++){
            result += `<br/><b>${inter[i].name}:</b> ${inter[i].review}<hr>`;   // blod reviewer name and review after it
        }

        response.send(result);  // sending response with reviews to client
    })

});

//-------------- post-requests -------------------
app.post("/purchasing", jsonParser, function (request, response) {
    // if any errors in request - set 400 http status
    if (!request.body)
        return response.sendStatus(400);

    // getting connection
    const connection = mysql.createConnection({
        host: dbdata.host,
        user: dbdata.user,
        password: dbdata.pass,
        database: dbdata.db
    });

    // getting order data
    const carid = request.body.carid;
    const buyername = request.body.buyername;
    const buyeraddress = request.body.buyeraddress;
    const buyerphone = request.body.buyerphone;

    // creating sql string and filter with data to set
    const sql = `INSERT INTO orders(name, address, phone, carID) VALUES (?, ?, ?, ?)`;
    const filter = [buyername, buyeraddress, buyerphone, carid];

    // sending order data to database
    connection.query(sql, filter, function (err, results) {
        if (err) throw err;

        console.log(results);
    });

    //ending connection
    connection.end();
});

app.post("/question", jsonParser, function (request, response) {
    // basicly here everything the same to previous function, so here nothing to comment

    if (!request.body)
        response.sendStatus(400);

    const connection = mysql.createConnection({
        host: dbdata.host,
        user: dbdata.user,
        password: dbdata.pass,
        database: dbdata.db
    });

    const name = request.body.name;
    const email = request.body.email;
    const ask = request.body.ask;

    const sql = `INSERT INTO asks(name, email, ask) VALUES(?, ?, ?)`;
    const filter = [name, email, ask];

    connection.query(sql, filter, function (err, results) {
        if (err) throw err;

        console.log(results);
    });

    connection.end();
});

app.post("/reviewSender", jsonParser, function (request, response) {
    // there are nothing changed to compare with previous 2 handlers
    if (!request.body)
        response.sendStatus(400);

    const connection = mysql.createConnection({
        host: dbdata.host,
        user: dbdata.user,
        password: dbdata.pass,
        database: dbdata.db
    });

    const name = request.body.name;
    const review = request.body.text;
    const rate = request.body.rate;
    const car = request.body.car;

    const sql = `INSERT INTO reviews(name, review, rate, carId) VALUES(?, ?, ?, ?)`;
    const filter = [name, review, rate, car];

    connection.query(sql, filter, function (err, results) {
        if (err) throw err;

        console.log(results);
    });

    connection.end();
});

//-------------- listening -----------------------
app.listen(3000, () => { console.log("Server started listening at 3000"); });