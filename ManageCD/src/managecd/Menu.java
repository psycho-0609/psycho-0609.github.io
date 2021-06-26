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
public class Menu {

    private Function function;
    private final Scanner scanner = new Scanner(System.in);
    private final int ADD_CD = 1;
    private final int DISPLAY_CD = 2;
    private final int GET_CD_2018 = 3;
    private final int EXIT = 4;

    public Menu() {
        function = new Function();
    }

    private void menu() {
        // display menu
        System.out.println("-------Menu-------");
        System.out.println("1. Them dia");
        System.out.println("2. Hien thi tat ca dia");
        System.out.println("3. Hien thi dia tu nam 2018");
        System.out.println("4. Exit");
    }

    private void runningMenu() {
        do {
            menu();
            int choice = inputOption();
            switch (choice) {
                case ADD_CD:
                    function.addCd(); // nếu choice = 1 thì gọi hàm addcd rong class function
                    break;
                case DISPLAY_CD:
                    function.displayCD(); // tương tự như trên
                    break;
                case GET_CD_2018:
                    function.displayCdFrom2018();
                    break;
                case EXIT:
                    System.out.println("Bye Bye <3");
                    System.exit(0); // thoát chương trình
                    break;
                default:
                    System.out.println("Lua chon khong phu hop. Vui long chon lai"); // new nhập không phai 1-4 thì nhập lại
                    break;
            }

        } while (true);

    }

    // lelect lựa chọn
    private Integer inputOption() {
        int choice = scanner.nextInt();
        return choice;
    }

    public void run() {
        runningMenu();
    }

}
