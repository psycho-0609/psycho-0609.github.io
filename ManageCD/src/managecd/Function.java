/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package managecd;

import java.util.Scanner;

/**
 *
 * @author Admin
 */
// bộ điều khiển và sử lý dữ liệu(add cd) để điều hướng đến các chức năng trong class processing
// processing sẽ có nhiệm vụ chính là thêm hiển thị dữ liệu
public class Function {
     private Processing processing;
    private final Scanner scanner = new Scanner(System.in);

    public Function() {
        processing = new Processing();
    }
    
    public  void addCd(){
        // nhập dự liệu
        System.out.print("Nhap ma dia: ");
        Integer id = scanner.nextInt();
        if(!validateId(id)){
            System.out.println("Ma san pham da ton tai");
            return;
        }
        System.out.print("Nhap ten dia: ");
        scanner.nextLine();
        String name = scanner.nextLine();
        if(!validateName(name)){
            System.out.println("San pham da ton tai");
            return;
        }
        System.out.print("Nhap the loai: ");
        String category = scanner.nextLine();
        System.out.print("Nhap name phat hanh: ");
        Integer year = scanner.nextInt();
        // tạo một đối tượng địa để lữu tất cả dự liệu cho dối tượng đó
        Dia cd = new Dia();
        // set data
        cd.setId(id);
        cd.setName(name);
        cd.setCategory(category);
        cd.setPublishedDate(year);
        // gọi hàm add trong class processing
        processing.addCD(cd);
    }
    
    public void displayCD(){
        // gọi hàm display trong class processing
        processing.displayCD();
    }
    
    public void displayCdFrom2018(){
        // gọi hàm displaycdFrom2018 trong class processing
        processing.getCdFrom2018();
    }
    
    private boolean validateId(Integer id){
        for(Dia itemDia:processing.getListCd()){
            if(itemDia.getId().equals(id)){
                return false;
            }
        }
        return true;
    }
    
       private boolean validateName(String name){
        for(Dia itemDia:processing.getListCd()){
            if(itemDia.getName().equals(name)){
                return false;
            }
        }
        return true;
    }
    
}
