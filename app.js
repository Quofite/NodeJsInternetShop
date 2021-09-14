const express = require("express");
const app = express();

const jsonParser = express.json();

const mysql = require("mysql2");
const dbdata = require("./dbdata");

//---

app.use(express.static(__dirname + "/views"));

app.set("view engine", "hbs");
const hbs = require("hbs");
hbs.registerPartials(__dirname + "/views/partials");

//-------------- custom functions ----------------


//-------------- get-requests --------------------
app.get("/", function (request, response) {
    response.sendFile(__dirname + "/views/index.html");
});

app.get("/ferrari488", function (request, response) {
    response.render("ferrari488");
});

app.get("/vaz2101", function (request, response) {
    response.render("vaz2101");
});

app.get("/dallaradw12", function (request, response) {
    response.render("dallaradw12");
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

//-------------- post-requests -------------------
app.post("/purchasing", jsonParser, function (request, response) {
    if (!request.body)
        return response.sendStatus(400);

    const connection = mysql.createConnection({
        host: dbdata.host,
        user: dbdata.user,
        password: dbdata.pass,
        database: dbdata.db
    });

    const carid = request.body.carid;
    const buyername = request.body.buyername;
    const buyeraddress = request.body.buyeraddress;
    const buyerphone = request.body.buyerphone;

    const sql = `INSERT INTO orders(name, address, phone, carID) VALUES (?, ?, ?, ?)`;
    const filter = [buyername, buyeraddress, buyerphone, carid];

    connection.query(sql, filter, function (err, results) {
        if (err) throw err;

        console.log(results);
    });

    connection.end();
});


//-------------- listening -----------------------
app.listen(3000, () => { console.log("Server started listening at 3000"); });