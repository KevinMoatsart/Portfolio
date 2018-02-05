package com.kevinmoatsart.www.listview2017;

/**
 * Created by moats on 10/7/2017.
 */

public class GroceryList {

    public enum STATUS
    {
        COMPLETE,
        INPROGRESS,
        DRAFT
    }


    private STATUS status;
    private int totalItems;
    private double totalPrice;
    private String title;

    public GroceryList(String title, STATUS status, int totalItems, double totalPrice) {
        this.title = title;
        this.status = status;
        this.totalItems = totalItems;
        this.totalPrice = totalPrice;
    }

    public String getTitle() {
        return title;
    }

    public STATUS getStatus() {
        return status;
    }

    public int getTotalItems() {
        return totalItems;
    }

    public double getTotalPrice() {
        return totalPrice;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public void setStatus(STATUS status) {
        this.status = status;
    }

    public void setTotalItems(int totalItems) {
        this.totalItems = totalItems;
    }

    public void setTotalPrice(double totalPrice) {
        this.totalPrice = totalPrice;
    }

}
