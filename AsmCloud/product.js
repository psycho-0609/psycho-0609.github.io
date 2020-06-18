const express = require('express');
var router = express.Router();
var publicDir = require("path").join(__dirname,'/public');
router.use(express.static(publicDir));
var MongoClient = require('mongodb').MongoClient;
var url = "mongodb+srv://hungdb:Luuhung123@cluster0-lb3x0.mongodb.net/test";



router.get('/',async (req,res)=>{   
    let client = await MongoClient.connect(url);
    let dbo = client.db("asmdb");
    let result = await dbo.collection("products").find({}).toArray();
    res.render('product',{products:result});
});
router.get('/delete',async (req,res)=>{
    let id = req.query.id;
    var ObjectID = require('mongodb').ObjectID;
    let condition = {"_id" : ObjectID(id)};
    let client= await MongoClient.connect(url);
    let dbo = client.db("asmdb");
    await dbo.collection("products").deleteOne(condition);
    //
    let results = await dbo.collection("products").find({}).toArray();
    res.render('product',{products:results});
});
router.get('/insert',async(req,res)=>{
    // let id = req.query.id;
    // var ObjectID = require('mongodb').ObjectID; 
    // let client = await MongoClient.connect(url);
    // let dbo = client.db('asmdb');
    // let result = await dbo.collection("products").findOne({'_id' : ObjectID(id)});
    res.render('insertProduct');
});
router.post('/doInsert',async(req,res)=>{
    let client= await MongoClient.connect(url);
    let dbo = client.db("asmdb");
    let nameValue = req.body.txtName;
    let priceValue = req.body.txtPrice;
    let detailValue = req.body.txtDetail;
    let authorValue = req.body.txtAuthor;
    let newProduct = {name : nameValue, author : authorValue, price: priceValue,detail:detailValue};
    await dbo.collection("products").insertOne(newProduct);
    console.log(newProduct);
    let results = await dbo.collection("products").find({}).toArray();
    res.render('product',{products:results});
});
router.get('/update',async(req,res)=>
{
    let id = req.query.id;
    var ObjectID = require('mongodb').ObjectID; 
    let cliet = await MongoClient.connect(url);
    let dbo = cliet.db('asmdb');
    let result = await dbo.collection("products").findOne({'_id' : ObjectID(id)});
    res.render('updateProduct',{products:result});
})
router.post('/doUpdate', async(req,res)=>{
    let id = req.body.id;
    let nameValue = req.body.txtName;
    let priceValue = req.body.txtPrice;
    let detailValue = req.body.txtDetail;
    let authorValue = req.body.txtAuthor;
    let newValues ={$set : {name: nameValue,author:authorValue,price:priceValue,detail:detailValue}};
    var ObjectID = require('mongodb').ObjectID;
    let condition = {"_id" : ObjectID(id)};
    
    let client= await MongoClient.connect(url);
    let dbo = client.db("asmdb");
    await dbo.collection("products").updateOne(condition,newValues);
    //
    let results = await dbo.collection("products").find({}).toArray();
    res.render('product',{products:results});
});



module.exports = router;