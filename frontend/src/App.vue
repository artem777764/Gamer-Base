<script setup lang="ts">
import { ref } from 'vue';
import MyForm from '@/components/MyForm.vue'
import SignedButton from '@/components/SignedButton.vue'
</script>

<template>
  <MyForm>
    <p class="font-russo leading-none text-white text-3xl text-center">Gamer Base</p>
    <MyInput placeholder="Email" v-model="test"></MyInput>
    <MyInput placeholder="Login"></MyInput>
    <MyInput placeholder="Password" is-password></MyInput>
    <SignedButton sign="Уже есть аккаунт?" class="">Зарегистрироваться</SignedButton>
  </MyForm>
</template>

<style>
.text-shadow {
  text-shadow: 1px 1px 2px black;
}
</style>