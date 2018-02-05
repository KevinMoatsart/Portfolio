package com.kevinmoatsart.www.listview2017;

import android.content.Context;
import android.support.annotation.IdRes;
import android.support.annotation.LayoutRes;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by moats on 9/30/2017.
 */

public class ProductAdapter extends ArrayAdapter<Product>
{
    private final Context context;
    private final ArrayList<Product> values;

    public ProductAdapter(Context context, ArrayList<Product> list) {
        super(context, R.layout.row_layout, list);
        this.context = context;
        this.values = list;
    }

    @NonNull
    @Override
    public View getView(int position, @Nullable View convertView, @NonNull ViewGroup parent) {
        LayoutInflater inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        View rowView = inflater.inflate(R.layout.row_layout, parent, false);

        TextView tvProduct = (TextView)rowView.findViewById(R.id.tvProduct);
        TextView tvPrice = (TextView)rowView.findViewById(R.id.tvPrice);
        TextView tvDescription = (TextView)rowView.findViewById(R.id.tvDescription);
        ImageView ivProduct = (ImageView)rowView.findViewById(R.id.ivProduct);
        ImageView ivSale = (ImageView)rowView.findViewById(R.id.ivSale);

        tvProduct.setText(values.get(position).getTitle());
        tvPrice.setText("R" + values.get(position).getPrice());
        tvDescription.setText(values.get(position).getDescription());

        if(values.get(position).getSale())
        {
            ivSale.setImageResource(R.mipmap.sale);
        }
        else
        {
            ivSale.setImageResource(R.mipmap.best_price);
        }

        if(values.get(position).getType().equals("Laptop"))
        {
            ivProduct.setImageResource(R.mipmap.laptop);
        }
        else if(values.get(position).getType().equals("Memory"))
        {
            ivProduct.setImageResource(R.mipmap.memory);
        }
        else if(values.get(position).getType().equals("HDD"))
        {
            ivProduct.setImageResource(R.mipmap.hdd);
        }
        else if(values.get(position).getType().equals("Screen"))
        {
            ivProduct.setImageResource(R.mipmap.screen);
        }

        return rowView;
    }
}
