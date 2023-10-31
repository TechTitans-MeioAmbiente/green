import 'package:firebase_core/firebase_core.dart';
import 'package:flutter/foundation.dart';

Future initFirebase() async {
  if (kIsWeb) {
    await Firebase.initializeApp(
        options: FirebaseOptions(
            apiKey: "AIzaSyDCb3E2juFkZwFFCyBF2_HVWj2JM3tar0U",
            authDomain: "green-hackweek-59057.firebaseapp.com",
            projectId: "green-hackweek-59057",
            storageBucket: "green-hackweek-59057.appspot.com",
            messagingSenderId: "665218291966",
            appId: "1:665218291966:web:78ed918035ac3ae96c2daf",
            measurementId: "G-S62C9ZK8ZN"));
  } else {
    await Firebase.initializeApp();
  }
}
