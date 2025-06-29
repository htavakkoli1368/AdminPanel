const routes = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      {
        path: '/',
        component: () => import('src/pages/UsersPage.vue')
      },
      {
        path: '/users',
        component: () => import('src/pages/UsersPage.vue')
      },
      {
        path: '/index',
        component: () => import('src/pages/IndexPage.vue')
      },
    ],
  } 
]

export default routes
