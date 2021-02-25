$(document).ready(function(){

    $("#btnMinus").click(function(){
        minusQuntityProduct();
    })

    $("#btnPlus").click(function(){
        plusQuantityProduct();
    })

    function plusQuantityProduct(){
        let element = $("#quantityProduct");
        let currentQuantity = parseInt(element.val());
        element.val(currentQuantity+1);
    }

    function minusQuntityProduct(){
        let element = $("#quantityProduct");
        let currentQuantity = element.val();
        if(currentQuantity - 1 <= 0){
            element.val(1);
        }else{
            element.val(currentQuantity-1);
        }
    }

    $(".list-img-product button").on("click",function(){
        let mainImg = $(".detail-product-img");
        mainImg.html($(this).html());
    })



})