package com.kevinmoatsart.www.fragmentexample;


import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v4.app.ListFragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ListView;


/**
 * A simple {@link Fragment} subclass.
 */
public class ListFrag extends ListFragment {

    private ChessPieceListener chessPieceListener;

    public ListFrag() {
        // Required empty public constructor
    }

    @Override
    public void onActivityCreated(@Nullable Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);

        setListAdapter(new ArrayAdapter<String>(this.getActivity(), android.R.layout.simple_list_item_1,
                getResources().getStringArray(R.array.pieces)));

        //phone in landscape
        if(this.getActivity().findViewById(R.id.layout_defualt) == null)
        {
            chessPieceListener.onChessPieceSelected(0);
        }
    }

    public interface ChessPieceListener
    {
        public void onChessPieceSelected(int index);
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);

        try
        {
            chessPieceListener = (ChessPieceListener)context;
        }
        catch(ClassCastException e)
        {
            throw new ClassCastException(context.toString() + " must implement the interface called" +
                    " chessPieceListener!");
        }
    }

    @Override
    public void onListItemClick(ListView l, View v, int position, long id) {
        chessPieceListener.onChessPieceSelected(position);
    }
}
