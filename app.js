const express = require("express");
const app = express();
app.use(express.static(__dirname + "/views"));
app.set("view engine", "hbs");

const hbs = require("hbs");
hbs.registerPartials(__dirname + "/views/partials");

const jsonParser = express.json();


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

//-------------- post-requests -------------------
app.post("/buyer", jsonParser, function (request, response) {
    console.log(request.body);

});


//-------------- listening -----------------------
app.listen(3000, () => { console.log("Server started listening at 3000"); });