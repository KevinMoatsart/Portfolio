package com.kevinmoatsart.www.sqliteexample;

import android.content.Intent;
import android.database.SQLException;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    EditText etName, etNumber;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        etName = (EditText)findViewById(R.id.etName);
        etNumber = (EditText)findViewById(R.id.etNumber);
    }

    public void btn_Submit(View v)
    {
        String name = etName.getText().toString().trim();
        String cell = etNumber.getText().toString().trim();

        try
        {
            ContactsDB db = new ContactsDB(this);
            db.open();
            db.createEntry(name, cell);
            db.close();
            Toast.makeText(this, "Successfully saved", Toast.LENGTH_SHORT).show();
            etName.setText("");
            etNumber.setText("");
        }
        catch (SQLException e)
        {
            Toast.makeText(this, e.getMessage(), Toast.LENGTH_SHORT).show();
        }
    }

    public void btnShowData(View v)
    {
        startActivity(new Intent(this, Data.class));
    }

    public void btnEditData(View v)
    {
        try
        {
            ContactsDB db = new ContactsDB(this);
            db.open();
            db.updateEntry("1", "Johan", "1112223333");
            db.close();
            Toast.makeText(this, "Successfully updated", Toast.LENGTH_SHORT).show();
        }
        catch (SQLException e)
        {
            Toast.makeText(this, e.getMessage(), Toast.LENGTH_SHORT).show();
        }
    }

    public void btnDeleteData(View v)
    {
        try
        {
            ContactsDB db = new ContactsDB(this);
            db.open();
            db.deleteEntry("1");
            db.close();
            Toast.makeText(this, "Successfully deleted", Toast.LENGTH_SHORT).show();
        }
        catch (SQLException e)
        {
            Toast.makeText(this, e.getMessage(), Toast.LENGTH_SHORT).show();
        }
    }
}
