package com.kevinmoatsart.www.firstapplication;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;

public class MainActivity extends AppCompatActivity {

    String tag = "Life Cycle Event";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main_activity);

        Log.d(tag, "in onCreate()");
    }

    @Override
    protected void onStart() {
        super.onStart();

        Log.d(tag, "in onStart()");
    }

    @Override
    protected void onResume() {
        super.onResume();

        Log.d(tag, "in onResume()");
    }

    @Override
    protected void onPause() {
        super.onPause();

        Log.d(tag, "in onPause()");
    }

    @Override
    protected void onStop() {
        super.onStop();

        Log.d(tag, "in onStop()");
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();

        Log.d(tag, "in onDestroy()");
    }

    @Override
    protected void onRestart() {
        super.onRestart();

        Log.d(tag, "in onRestart()");
    }
}
