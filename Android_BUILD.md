# Android build guide (Unity 2021.3 LTS)

This file explains how to build an Android .aab for publishing. Follow Unity's official docs for any step that is unclear.

1) Install Android Build Support
- In Unity Hub, install Android Build Support (SDK, NDK, OpenJDK).

2) Player Settings
- File > Build Settings > Android > Switch Platform.
- Player Settings:
  - Company Name / Product Name: set appropriately
  - Package Name (Bundle Identifier): com.yourname.myanmarlife
  - Set Minimum API Level (Android 7.0+ recommended)
  - Set Scripting Backend: IL2CPP (recommended) or Mono for faster iteration

3) Configure Keystore (for release builds)
- Edit > Project Settings > Player > Publishing Settings (Android)
- Create a new keystore or provide your existing one. Keep the keystore and passwords safe.
- For local development you can use a debug keystore, but for Play Store you must use a release keystore.

4) Build App Bundle (.aab)
- File > Build Settings > Build System: Gradle (recommended)
- Build > Build and Run (or Build) — choose a folder, Unity will produce an .aab file.

5) Testing
- Use internal testing in Google Play Console or install the generated APK (if you build APK) on a device.

6) Publishing (high level)
- Create a Google Play Developer account (one-time fee) and an app entry.
- Upload the .aab, provide store listing (screenshots, description), content rating, and privacy policy.

7) CI / Automation (optional)
- You can use GitHub Actions to build an .aab; the runner must have Unity installed or use actions that provide Unity caches.
- Secure your keystore/passwords using GitHub Secrets.

Security notes
- Never commit your keystore or passwords to the repository. Store them in a secure place and use CI secrets for automated builds.

