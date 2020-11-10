'use strict';
const express = require('express');
const path = require('path');

const dotenv = require('dotenv');
dotenv.config();

const app = express();

app.use(express.static(path.join(__dirname, '')));

app.set('port', process.env.SERVER_PORT);

app.listen(app.get('port'));
console.log('Listening on: ', app.get('port'));
