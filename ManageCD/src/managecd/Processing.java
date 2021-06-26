/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package managecd;

import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Admin
 */
// handle all function of programs
public class Processing {

    //create list to store Dia
    private List<Dia> list;

    public Processing() {
        this.list = new ArrayList<>();
    }

    // add new cd to list
    public void addCD(Dia cd) {
        this.list.add(cd);
    }

    // get cd from 2018
    public void getCdFrom2018() {
        // create new list to store cd
        List<Dia> newList = new ArrayList<>();
        // run loop to find all cd from 2018
        for (Dia item : list) {
            if (item.getPublishedDate() >= 2018) {
                //cdd in new lists
                newList.add(item);
            }
        }
        // display cd
        if (newList.size() > 0) {
            System.out.println("Tat ca dia tu nam 2018");
            display(newList);
        } else {
            System.out.println("Khong co dia nao trong kho!");
        }

    }

    //function to display cd
    private void display(List<Dia> list) {
        // (%-12s%-12s%-12s%s\n) is format to display 

        System.out.printf("%-12s%-12s%-12s%s\n", "MA dia", "Ten dia", "The loai", "Nam phat hanh");
        for (Dia item : list) {
            System.out.printf("%-12s%-12s%-12s%s", item.getId(), item.getName(), item.getCategory(), item.getPublishedDate(), item.getPublishedDate());
            System.out.println("");
        }
    }

    // display all cd in list
    public void displayCD() {
        if (list.size() > 0) {
            System.out.println("Tat ca dia");
            display(list);
        } else {
            System.out.println("Khong co dia nao trong kho!");
        }
    }

    public List<Dia> getListCd() {
        return list;
    }
}
