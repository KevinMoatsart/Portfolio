package com.kevinmoatsart.www.asynctaskexample;

import android.app.ProgressDialog;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import java.util.Random;

public class MainActivity extends AppCompatActivity {

    EditText etRolls;
    Button btnRoll;
    TextView tvOutput;
    ProgressBar pbRollingDice;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        etRolls = (EditText)findViewById(R.id.etRolls);
        btnRoll = (Button)findViewById(R.id.btnRoll);
        tvOutput = (TextView)findViewById(R.id.tvOutput);
        pbRollingDice = (ProgressBar)findViewById(R.id.pbRollingDice);

        pbRollingDice.setVisibility(ProgressBar.INVISIBLE);

        btnRoll.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                int numberOfTimes = Integer.parseInt(etRolls.getText().toString().trim());

                new ProcessDiceInBackground().execute(numberOfTimes);

            }
        });
    }

    public class ProcessDiceInBackground extends AsyncTask<Integer, Integer, String>
    {
        @Override
        protected void onPreExecute() {
            super.onPreExecute();

            pbRollingDice.setMax(Integer.parseInt(etRolls.getText().toString().trim()));
            pbRollingDice.setVisibility(ProgressBar.VISIBLE);
        }

        @Override
        protected String doInBackground(Integer... params) {
            int ones = 0, twos = 0, threes = 0, fours = 0, fives = 0, sixes = 0, randomNumber;

            Random random = new Random();

            String results;

            double currentProgress = 0;
            double previousProgress = 0;

            for(int i = 0; i < params[0]; i++)
            {

                currentProgress = (double)i / params[0];

                if(currentProgress - previousProgress >= 0.02)
                {
                    publishProgress(i);
                    previousProgress = currentProgress;
                }

                randomNumber = random.nextInt(6) + 1;

                switch (randomNumber)
                {
                    case 1: ones++;
                        break;
                    case 2: twos++;
                        break;
                    case 3: threes++;
                        break;
                    case 4: fours++;
                        break;
                    case 5: fives++;
                        break;
                    case 6: sixes++;
                        break;

                }
            }

            results = "Results: \n1: " + ones + "\n2: " + twos + "\n3: " + threes + "\n4: " + fours + "\n5: " + fives + "\n6: " + sixes;
            return results;
        }

        @Override
        protected void onProgressUpdate(Integer... values)
        {
            super.onProgressUpdate(values);

            pbRollingDice.setProgress(values[0]);
        }

        @Override
        protected void onPostExecute(String s) {
            super.onPostExecute(s);

            pbRollingDice.setVisibility(ProgressBar.INVISIBLE);
            tvOutput.setText(s);
            Toast.makeText(MainActivity.this, "Process done!", Toast.LENGTH_SHORT).show();
        }
    }
}
