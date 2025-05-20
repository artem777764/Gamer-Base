<script setup lang="ts">
import MyForm from '@/components/MyForm.vue';
import SignedButton from '@/components/SignedButton.vue';
</script>

<template>
    <div class="min-h-screen bg-background flex justify-center items-center">
        <MyForm>
            <p class=" font-russo leading-none text-white text-3xl text-center">Gamer Base</p>
            <MyInput placeholder="Email"></MyInput>
            <MyInput placeholder="Login"></MyInput>
            <MyInput placeholder="Password" is-password></MyInput>
            <SignedButton sign="Уже есть аккаунт?" class="">Зарегистрироваться</SignedButton>
        </MyForm>
    </div>
</template>