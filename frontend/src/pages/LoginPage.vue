<script setup lang="ts">
import MyForm from '@/components/MyForm.vue';
</script>

<template>
    <div class="min-h-screen bg-background flex justify-center items-center">
        <MyForm>
            <p class=" font-russo leading-none text-white text-3xl text-center">Gamer Base</p>
            <MyInput placeholder="Email/Login"></MyInput>
            <MyInput placeholder="Password" is-password></MyInput>
            <div class="flex flex-col gap-0 items-center">
                <MyButton class="w-full">
                    Войти
                </MyButton>
                <router-link to="/register">
                    <p class="font-russo leading-none text-gray-300 text-xs underline mt-1">Не зарегистрированны?</p>
                </router-link>
            </div>
        </MyForm>
    </div>
</template>