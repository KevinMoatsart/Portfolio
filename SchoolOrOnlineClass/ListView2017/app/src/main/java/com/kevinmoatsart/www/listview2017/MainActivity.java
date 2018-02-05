package com.kevinmoatsart.www.listview2017;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.ListView;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {

    ListView lvProducts;
    ArrayList<Product> list;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        lvProducts = (ListView) findViewById(R.id.lvProducts);

        list = new ArrayList<Product>();

        Product product1 = new Product("BenQ",
                "A super cool screen.",
                "Screen",
                399.00,
                true);
        Product product2 = new Product("Big laptop",
                "A gaming laptop.",
                "Laptop",
                3999.00,
                false);
        Product product3 = new Product("Corsair 16GB",
                "Makes ye computer like 1% faster.",
                "Memory",
                3992.00,
                true);
        Product product4 = new Product("1TB Hard Drive",
                "Some more storage of course.",
                "HDD",
                39.00,
                false);

        list.add(product1);
        list.add(product2);
        list.add(product3);
        list.add(product4);

        ProductAdapter adapter = new ProductAdapter(this, list);

        lvProducts.setAdapter(adapter);
    }
}
