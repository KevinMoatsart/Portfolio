package com.kevinmoatsart.www.sqliteexample;

import android.database.SQLException;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.TextView;
import android.widget.Toast;

public class Data extends AppCompatActivity {

    TextView tvData;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_data);

        tvData = (TextView)findViewById(R.id.tvData);

        try
        {
            ContactsDB db = new ContactsDB(this);
            db.open();
            String result = db.getData();
            db.close();
            tvData.setText(result);
            Toast.makeText(this, "Successfully loaded data", Toast.LENGTH_SHORT).show();
        }
        catch (SQLException e)
        {
            Toast.makeText(this, e.getMessage(), Toast.LENGTH_SHORT).show();
        }
    }
}
