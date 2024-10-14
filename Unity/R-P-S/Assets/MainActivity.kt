package com.example.wifitracker

import android.Manifest
import android.R
import android.content.BroadcastReceiver
import android.content.Context
import android.content.Intent
import android.content.IntentFilter
import android.content.pm.PackageManager
import android.net.wifi.ScanResult
import android.net.wifi.WifiManager
import android.os.Bundle
import android.util.Log
import android.view.Menu
import android.view.MenuItem
import android.view.View
import android.widget.SimpleAdapter
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import androidx.core.app.ActivityCompat
import androidx.core.content.ContextCompat
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.example.wifitracker.databinding.ActivityMainBinding


class MainActivity : AppCompatActivity() {
    lateinit var wifiManager: WifiManager
    private val REQUEST_LOCATION_PERMISSION = 1

    private fun isPermissionGranted() : Boolean {
        return ContextCompat.checkSelfPermission(
                this,
                Manifest.permission.ACCESS_FINE_LOCATION) == PackageManager.PERMISSION_GRANTED
    }
    private lateinit var binding: ActivityMainBinding
    private lateinit var adapter: WifiResultAdapter
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        //setContentView(R.layout.activity_main)
        //setSupportActionBar(findViewById(R.id.toolbar))
        binding = ActivityMainBinding.inflate(layoutInflater)
        if (!isPermissionGranted()) {
            ActivityCompat.requestPermissions(
                    this,
                    arrayOf<String>(Manifest.permission.ACCESS_FINE_LOCATION),
                    REQUEST_LOCATION_PERMISSION
            )
            if (!isPermissionGranted())
                return
        }
        Log.i("WifiTracker", isPermissionGranted().toString())

        wifiManager = getApplicationContext().getSystemService(Context.WIFI_SERVICE) as WifiManager
        val wifiScanReceiver = object : BroadcastReceiver() {

            override fun onReceive(context: Context, intent: Intent) {
                val success = intent.getBooleanExtra(WifiManager.EXTRA_RESULTS_UPDATED, false)
                if (success) {
                    scanSuccess()
                } else {
                    scanFailure()
                }
            }
        }

        val intentFilter = IntentFilter()
        intentFilter.addAction(WifiManager.SCAN_RESULTS_AVAILABLE_ACTION)
        registerReceiver(wifiScanReceiver, intentFilter)

        //https://developer.android.com/codelabs/kotlin-android-training-recyclerview-fundamentals?hl=pt#3
        adapter = WifiResultAdapter()
        binding.networkList.adapter = adapter
    }

    private fun scanSuccess() {
        val results = wifiManager.scanResults
        //BSSID - Unique ID
        //ssid = SSID
        //level = RSSI
        //frequency =  frequency (ale trzeba będzie jakieś bajo jajo wykonać)
        results.forEach{
            val mac = it.BSSID
            val ssid = it.SSID
            val rssi = it.level
            val frequency = it.frequency;
            val distance = 15;//calcs
            Log.i("WifiTracker", String.format("SSID: $ssid\nMAC: $mac ${distance}m\n${frequency}Mhz RSSI: $rssi"))
        }
        adapter.updateData(results)
        adapter.notifyDataSetChanged()
        Log.i("WifiTracker", "Scan success")
        Toast.makeText(applicationContext, "Scan successful mordo", Toast.LENGTH_SHORT).show()
    }

    private fun scanFailure() {
        Log.i("WifiTracker", "Scan failure")
    }
}

