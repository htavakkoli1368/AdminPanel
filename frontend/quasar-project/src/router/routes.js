// ...existing code...
const routes = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      { path: '', component: () => import('pages/LoginPage.vue') },
      { path: 'dashboard', component: () => import('pages/DashboardPage.vue') },
      { path: 'water', component: () => import('pages/WaterPage.vue') },
      { path: 'electricity', component: () => import('pages/ElectricityPage.vue') },
      { path: 'gas', component: () => import('pages/GasPage.vue') },
      { path: 'settings', component: () => import('pages/SettingsPage.vue') },
    ],
  },
  // ...existing code...
]
// ...existing code...
export default routes
// ...existing code...
