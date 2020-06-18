
const express = require('express');
var router = express.Router();

router.get('',(req,res)=>{
    res.render('index');
})
router.post('/doLogin',(req,res)=>{
    let name = req.body.txtName;
    let password = req.body.txtPassword;
    if(password =='123@'){
        res.render('index');
    }else{
        res.end('Login failed!');
    }
})

module.exports = router;