$(document).ready(function(){
   
    $("#interBank").click(function(){
        $("#interBankInfor").slideDown();
        $("#visaCardBox").slideUp();
    })
    $("#cash").click(function(){
        $("#interBankInfor").slideUp();
        $("#visaCardBox").slideUp();
    })

    $("#visa").click(function(){
        $("#visaCardBox").slideDown();
        $("#interBankInfor").slideUp();

    })



    $("#numberCard").focus(function(){
        $("#cardVisaInfor").removeClass("active-rotage")
        let number = $("#detailNumber");
        let input = $("#numberCard")
        $("#detailNumber").addClass("active-hightlight");
        $(".date-card").removeClass("active-hightlight")
        $("#owerName").removeClass("active-hightlight");

        $("#numberCard").keyup(function(){
            let value = input.val();
            if(plusString(value).length <= 20){
                number.text(plusString(value,16))
            }
        })
       
    })
   
    $("#name").focus(function(){
        $("#cardVisaInfor").removeClass("active-rotage")
        $("#detailNumber").removeClass("active-hightlight");
        $(".date-card").removeClass("active-hightlight")
        $("#owerName").addClass("active-hightlight");
        let ownerName = $("#owerName"); 
        let inputName = $("#name");
        $("#name").keyup(function(){
            if(inputName.val() == "" || inputName.val() == null){
                ownerName.text('Tên Chủ Thẻ');
            }else{
                ownerName.text(inputName.val());
            }
        })
        
        
        
    })

    $("#inputDay").focus(function(){
        $("#cardVisaInfor").removeClass("active-rotage")


        $("#detailNumber").removeClass("active-hightlight");
        $("#owerName").removeClass("active-hightlight");
        $(".date-card").removeClass("active-hightlight")
        $(".date-card").addClass("active-hightlight")


        $("#inputDay").keyup(function(){
            let value = $("#inputDay").val();
            if(plusStringv2(value).length < 3){
                $("#day").text(plusStringv2(value))
            }
        })
    })

    $("#inputMonth").focus(function(){
       
        $("#cardVisaInfor").removeClass("active-rotage")

        $("#detailNumber").removeClass("active-hightlight");
        $("#owerName").removeClass("active-hightlight");
        $(".date-card").removeClass("active-hightlight")
        $(".date-card").addClass("active-hightlight")

        $("#inputMonth").keyup(function(){
            let value = $("#inputMonth").val();
            if(plusStringv2(value).length < 3){
                $("#month").text(plusStringv2(value))
            }
        })

    })

    $("#inputPrivateNumber").focus(function(){
        $("#cardVisaInfor").addClass("active-rotage")
        $("#inputPrivateNumber").keyup(function(){
            let value = $("#inputPrivateNumber").val();
            if(value.length <= 3){
                $("#privateNumber").text(value);
            }
        })
    })

   

    function plusString(number){
        let x = "•";
        while(number.length < 16){
            number+=x;
        }
        number = number.split("");
        
        return processString(number);
    }

    function processString(string){
        let result = '';
        for(let i = 0; i < string.length; i++){
            if(i!=0 && (i+1)%4==0){
                result+=string[i] +" ";
            }else{
                result+=string[i] 
            }
        }
        return result;
    }

    function plusStringv2(number){
        let x = "•";
        while(number.length < 2){
            number+=x;
        }
        
        return number;
    }
})