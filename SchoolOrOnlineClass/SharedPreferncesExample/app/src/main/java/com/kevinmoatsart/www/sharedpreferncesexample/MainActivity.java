package com.kevinmoatsart.www.sharedpreferncesexample;

import android.content.SharedPreferences;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Display;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    TextView tvWelcome;
    EditText etName;
    Button btnSubmit;

    public static final String MY_PREFS_FILENAME = "com.kevinmoatsart.www.sharedpreferncesexample.Names";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        tvWelcome = (TextView)findViewById(R.id.tvWelcome);
        etName = (EditText)findViewById(R.id.etName);
        btnSubmit = (Button)findViewById(R.id.btnSubmit);

        SharedPreferences prefs = getSharedPreferences(MY_PREFS_FILENAME, MODE_PRIVATE);
        String user = prefs.getString("name", "");

        tvWelcome.setText("Welcome to my app " + user + "!");

        btnSubmit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String name = etName.getText().toString().trim();
                tvWelcome.setText("Welcome to my app " + name + "!");

                SharedPreferences.Editor editor = getSharedPreferences(MY_PREFS_FILENAME, MODE_PRIVATE).edit();
                editor.putString("name", name);
                editor.commit();
            }
        });
    }
}
